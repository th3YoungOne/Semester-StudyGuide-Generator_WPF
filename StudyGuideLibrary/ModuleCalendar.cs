using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideLibrary
{
    //calendar class for each module --> allows the user to interact with a calendar to save their study information
    public class ModuleCalendar
    {
        public DateTime studyDate { get; set; }
        public double hoursStudied { get; set; }
    }
}
