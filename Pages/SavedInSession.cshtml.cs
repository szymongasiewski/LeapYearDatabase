using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LeapYearDatabase.Models;

namespace LeapYearDatabase.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<string[]> List;

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("CheckedList");
            if (Data != null)
                List = JsonConvert.DeserializeObject<List<string[]>>(Data);
        }
    }
}
