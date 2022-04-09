using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYearDatabase.Data;
using LeapYearDatabase.Models;

namespace LeapYearDatabase.Pages
{
    public class RecentlySearchedModel : PageModel
    {
        private readonly LeapYearContext _context;

        public IList<LeapYear> LeapYears { get; set; }

        public RecentlySearchedModel(LeapYearContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            LeapYears = _context.LeapYear.OrderByDescending(l => l.Date).Take(20).ToList();
        }

        public IActionResult OnPostDeleteRecord(int RecordId)
        {
            _context.Remove(_context.LeapYear.Single(l => l.Id == RecordId));
            _context.SaveChanges();
            return RedirectToPage("./RecentlySearched");
        }
    }
}
