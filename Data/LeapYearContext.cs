using Microsoft.EntityFrameworkCore;
using LeapYearDatabase.Models;

namespace LeapYearDatabase.Data
{
    public class LeapYearContext : DbContext
    {
        public LeapYearContext (DbContextOptions options) : base(options) { }
        public DbSet<LeapYear> LeapYear { get; set; }
    }
}
