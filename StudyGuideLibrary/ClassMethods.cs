using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideLibrary
{
    //methods
    public class ClassMethods
    {
        //calculates and returns the study hours for the module
        public int studyHours(int modCredits) { return modCredits * 10; }
        //calculates and returns the study hours required by the user weekly
        public int weeklyHours(int studyHrs, int numWeeks, int classHrs) { return (int)((studyHrs / numWeeks) - classHrs); }
    }

    //semeter class --> saves all semster information for the user
    class Semester
    {
        public int weeks { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    //module class --> saves all the different sets of module information for the user
    class Module
    {
        public string code { get; set; }
        public string name { get; set; }
        public string credits { get; set; }
        public string hrsPerWeek { get; set; }
    }

    //calendar class for each module --> allows the user to interact with a calendar to save their study information
    class ModuleCalendar
    {
        public int selfStudyHours { get; set; }
        public int studyHoursWeekly { get; set; }
        public List<(DateTime date, int hoursStudied)> studyEntries { get; set; }
    }
}
