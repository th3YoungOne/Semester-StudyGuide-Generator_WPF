using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideLibrary
{
    //module class --> saves all the different sets of module information for the user
    public class Module
    {
            public string code { get; set; }
            public string name { get; set; }
            public string credits { get; set; }
            public string hrsPerWeek { get; set; }

    }
}
