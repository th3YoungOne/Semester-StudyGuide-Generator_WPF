using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideLibrary
{
    //class that contains all methods
    public class ClassMethods
    {
        //calculates and returns the study hours for the module
        public int studyHours(int modCredits) { return modCredits * 10; }
        //calculates and returns the study hours required by the user weekly
        public int weeklyHours(int studyHrs, int numWeeks, int classHrs) { return (int)((studyHrs / numWeeks) - classHrs); }
    }
}
