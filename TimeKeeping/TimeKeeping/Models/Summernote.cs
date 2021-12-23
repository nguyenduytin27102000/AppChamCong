using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeKeeping.Models
{
    public class Summernote
    {
        public Summernote(string iDEditor, bool load = true)
        {
            IDEditor = iDEditor;
            LoadLibrary = load;
        }
        public string IDEditor { get; set; }
        public bool LoadLibrary { get; set; }
        public int height { get; set; } = 200;
        public string toolbar { get; set; } = @"
            [
              ['style', ['style']],
              ['font', ['bold', 'underline', 'clear']],
              ['color', ['color']],
              ['para', ['ul', 'ol', 'paragraph']],
              ['table', ['table']],
              ['insert', ['link', 'picture', 'video']],
              ['view', ['fullscreen', 'codeview', 'help']]
            ]
        ";


    }
}
