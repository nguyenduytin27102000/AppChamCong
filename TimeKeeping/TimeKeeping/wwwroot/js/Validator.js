function Validator(formSelector, groupSelector, messageSelector, invalidClassName){
    const formRules = {};
    const validatorMethods = {
        required: function(value){
            return value ? undefined : 'Blanks are not allowed';
        },
        minLength: function(minLength){
            return function(value){
                return value.length >= minLength ? undefined : `Must not be less than ${minLength} characters`;
            }
        },
        boxChecked: function(name){
            const boxes = document.querySelectorAll(`input[name="${name}"]:checked`);
            console.log(boxes.length);
            return boxes.length > 0 ? undefined : 'You must choose at least one';
        },
        uniqueDate: function(value){
            const dateInputs = document.querySelectorAll('input[type="date"]');
            let count = 0;
            let result;
            dateInputs.forEach(e => {
                if(e.value == value) count++;
                if(count == 2){
                    result = true;
                }
            });
            return result ? 'Selected date already exists' : undefined;
        },
        greaterEqual: function (selector) {
            return function (value) {
                const previous = document.querySelector(selector);
                const label = getParentElement(previous, groupSelector).querySelector('label').innerText;
                return previous.value <= value ? undefined : `Must greater than ${label}`;
            }
        }
    }
    const formElement = document.querySelector(formSelector);
    if(formElement){
        const inputElements = formElement.querySelectorAll('[name][rules]');
        for(let inputElement of inputElements){
            const rules = inputElement.getAttribute('rules').split('|');
            // let inputName = inputElement.name.includes('[]') ? inputElement.name.substring(0, inputElement.name.length - 2) : inputElement.name;
            formRules[inputElement.name] = [];
            for(let rule of rules){
                let ruleMethod;
                if(rule.includes(':')){
                    const complexRules = rule.split(':');
                    ruleMethod = validatorMethods[complexRules[0]](complexRules[1]);
                }
                else ruleMethod = validatorMethods[rule];
                formRules[inputElement.name].push(ruleMethod);
            }
            
            // add event for input
            
            if(inputElement.type == 'checkbox'){
                const chkboxes = document.querySelectorAll(`input[type="checkbox"][name="${inputElement.name}"]`);
                for (let i = 0; i < chkboxes.length; i++) {
                    const element = chkboxes[i];
                    element.onclick = handleChecked;
                }
            }
            else{
                inputElement.onblur = handleValidate;
                inputElement.oninput = handleClearError;
            }
        }

        function handleChecked(e){
            const errorMessage = formRules[e.target.name][0](e.target.name);
            const parent = getParentElement(e.target, groupSelector);
            const formMessage = parent.querySelector(messageSelector);
            if(errorMessage){
                e.target.checked = false;
                parent.classList.add(invalidClassName);
                
                console.dir(e.target.removeAttribute('checked'));
                
                if(formMessage){
                    formMessage.innerText = errorMessage;
                }
            }
            else{
                parent.classList.remove(invalidClassName);
                if(formMessage){
                    formMessage.innerText = '';
                }
            }
            return !errorMessage;
        }

        function handleValidate(e){
            const rules = formRules[e.target.name];
            let errorMessage;
            for(rule of rules){                
                errorMessage = rule(e.target.value);
                if(errorMessage){
                    break; 
                }
            }
            // show invalid message
            if(errorMessage){
                const parent = getParentElement(e.target, groupSelector);
                const formMessage = parent.querySelector(messageSelector);
                parent.classList.add(invalidClassName);
                if(formMessage){
                    formMessage.innerText = errorMessage;
                }
            }
            return !errorMessage;
        }

        function handleClearError(e){
            const parent = getParentElement(e.target, groupSelector);
            const formMessage = parent.querySelector(messageSelector);
            if(parent.classList.contains(invalidClassName)){
                parent.classList.remove(invalidClassName);
            }
            if(formMessage){
                formMessage.innerText = '';
            }
        }
    }
    function getParentElement(currentElement, selector){
        while(currentElement.parentElement){
            if(currentElement.parentElement.matches(groupSelector)){
                return currentElement.parentElement;
            }
            currentElement = currentElement.parentElement;
        }
    }

    formElement.onsubmit = function(e){
        e.preventDefault();
        const inputs = formElement.querySelectorAll('[name][rules]');
        let isValid = true;
        for(let input of inputs){
            if(input.type == 'checkbox'){
                if(!handleChecked({target: input}))
                    isValid = false;
            }
            else if(!handleValidate({target : input})){
                isValid = false;
            }
        }
        if(isValid) formElement.submit();
    }
    return {
        update : function(){
            Validator(formSelector, groupSelector, messageSelector, invalidClassName);            
        }
    }
}