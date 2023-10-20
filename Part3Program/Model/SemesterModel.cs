using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Part3Program.Model
{
    public class SemesterModel : PageModel
    {
        [BindProperty]
        public string? Semester { get; set; }
        [BindProperty]
        public string? weeks { get; set; }
        [BindProperty]
        public DateTime startDate { get; set; }

        //create onget and onpost methods

        public IActionResult onGet() { return RedirectToPage("/Index"); }
    }
}
