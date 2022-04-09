using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeapYearDatabase.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LeapYearDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace LeapYearDatabase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LeapYearContext _context;

        [BindProperty]
        public LeapYear LeapYear { get; set; }

        public string[] Arr;
        public IList<LeapYear> LeapYears { get; set; }

        public IndexModel(ILogger<IndexModel> logger, LeapYearContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                LeapYear.Date = DateTime.Now;

                Arr = new string[4];
                Arr[0] = LeapYear.Name;
                Arr[1] = LeapYear.Surname;
                Arr[2] = LeapYear.Year.ToString();
                Arr[3] = LeapYear.IsLeapYear(LeapYear.Year);


                List<string[]> List;

                var Data = HttpContext.Session.GetString("CheckedList");
                if (Data != null)
                    List = JsonConvert.DeserializeObject<List<string[]>>(Data);
                else
                    List = new List<string[]>();

                List.Add(Arr);
                HttpContext.Session.SetString("CheckedList", JsonConvert.SerializeObject(List));

                LeapYears = _context.LeapYear.ToList();
                _context.LeapYear.Add(LeapYear);
                _context.SaveChanges();

            }
            return Page();
        }
    }
}