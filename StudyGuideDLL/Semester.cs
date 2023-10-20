using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuideDLL
{
    //semeter class --> saves all semster information for the user
    public class Semester
    {
        [Key]
        public int semester_id { get; set; }
        [Required]
        public int weeks { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
    }
}
