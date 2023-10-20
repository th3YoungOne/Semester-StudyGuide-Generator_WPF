using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideDLL
{
    //module class --> saves all the different sets of module information for the user
    public class Module
    {
        [Key]
        public int module_id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int credits { get; set; }
        [Required]
        public int classHrsPerWeek { get; set; }
        public ICollection<ModuleCalendar> ModuleCalendars { get; set; }
    }
}
