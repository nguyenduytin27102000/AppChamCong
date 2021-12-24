using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;

namespace TimeKeeping.ViewModels.Personnels
{
    public class PersonnelDetailModel
    {
        public string PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public string PersonnelAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public decimal ActualSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? OfficialDate { get; set; }


        //-----------------------------//
        public Office Office { get; set; }
        public Position Position { get; set; }
        public SalaryPolicy SalaryPolicy { get; set; }
        public TypePersonnel TypePersonnel { get; set; }
        public WorkSchedule WorkSchedule { get; set; }
        public WorkingArea WorkingArea { get; set; }
    }
}
