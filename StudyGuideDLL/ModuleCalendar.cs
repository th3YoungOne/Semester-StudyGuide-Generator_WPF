using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideDLL
{
    //calendar class for each module --> allows the user to interact with a calendar to save their study information
    public class ModuleCalendar
    {
        [Key]
        public int calendar_id { get; set; }
        [Required]
        public DateTime studyDate { get; set; }
        [Required]
        public double hoursStudied { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
