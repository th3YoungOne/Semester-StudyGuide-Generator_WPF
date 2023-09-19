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
        public ObservableCollection<Module> readModDoc(string docName)
        {
            ObservableCollection<Module> modules= new ObservableCollection<Module>();

            //Declare a new XML Document Object
            XDocument readDoc = XDocument.Load(docName);

            foreach (var modElement in readDoc.Descendants("Module"))
            {
                Module module = new Module
                {
                    code = modElement.Element("ModuleInfo")?.Element("Code")?.Value,
                    name = modElement.Element("ModuleInfo")?.Element("Name")?.Value,
                    credits = int.TryParse(modElement.Element("ModuleInfo")?.Element("Credits")?.Value, out int credits) ? credits : 0,
                    classHrsPerWeek = int.TryParse(modElement.Element("ModuleInfo")?.Element("HoursPerWeek")?.Value, out int classHrsPerWeek) ? classHrsPerWeek : 0,
                };
                modules.Add(module);
            }

            return modules;

            ////loads all modules from the xml file into a list of modules
            //var moduleData = readDoc.Descendants("Module").Select(module => new Module 
            //{
            //    code = module.Element("ModuleInfo")?.Element("Code")?.Value,
            //    name = module.Element("ModuleInfo")?.Element("Name")?.Value,
            //    credits = int.TryParse(module.Element("ModuleInfo")?.Element("Credits")?.Value, out int credits) ? credits : 0,
            //    classHrsPerWeek = int.TryParse(module.Element("ModuleInfo")?.Element("HoursPerWeek")?.Value, out int classHrsPerWeek) ? classHrsPerWeek : 0,
            //});

            //return moduleData;
        }
    }
}
