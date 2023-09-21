using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudyGuideLibrary
{
    //class that contains all methods
    public class ClassMethods
    {
        //calculates and returns the study hours for the module
        public int totStudyHours(int modCredits) { return modCredits * 10; }
        //calculates and returns the study hours required by the user weekly
        public double weeklyHours(double credits, double numWeeks, double classHrs) 
        {
            double totHrs = credits * 10;
            double totClassHrs = classHrs * numWeeks;
            return (totHrs - totClassHrs) / numWeeks;
        }

        //reads from the Semester xml Doc
        public Semester readSemDoc(string docName)
        {
            //reading XML Document Object
            XDocument readDoc = XDocument.Load(docName);

            //read from xml file
            var semesterData = readDoc.Descendants("Semester").Select(semester => new Semester
            {
                weeks = int.TryParse(semester.Element("SemesterInfo")?.Element("Duration")?.Value, out int duration) ? duration : 0,
                startDate = DateTime.TryParse(semester.Element("SemesterInfo")?.Element("StartDate")?.Value, out DateTime startDate) ? startDate : DateTime.MinValue,
                endDate = DateTime.TryParse(semester.Element("SemesterInfo")?.Element("EndDate")?.Value, out DateTime endDate) ? endDate : DateTime.MinValue
            }).FirstOrDefault();

            return semesterData;
        }
    }
}
