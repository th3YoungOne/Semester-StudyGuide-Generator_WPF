using System;
using System.Collections.Generic;
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
        public int studyHours(int modCredits) { return modCredits * 10; }
        //calculates and returns the study hours required by the user weekly
        public int weeklyHours(int studyHrs, int numWeeks, int classHrs) { return (int)((studyHrs / numWeeks) - classHrs); }


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

        //reads from the Module xml Doc
        public List<Module> readModDoc(string docName)
        {
            List<Module> modules = new List<Module>();

            //Declare a new XML Document Object
            XDocument accDoc = XDocument.Load(docName);

            var qr = from request in accDoc.Descendants("Module")
                     select new Module
                     {
                         code = request.Element("Code").Value,
                         name = request.Element("Name").Value,
                         credits = int.Parse(request.Element("Credit").Value),
                         classHrsPerWeek = int.Parse(request.Element("ClassHours").Value)
                     };

            modules.AddRange(qr);
            return modules;
        }
    }
}
