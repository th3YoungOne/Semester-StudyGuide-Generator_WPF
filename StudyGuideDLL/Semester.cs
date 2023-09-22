using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideDLL
{
    //semeter class --> saves all semster information for the user
    public class Semester
    {
        public int weeks { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
