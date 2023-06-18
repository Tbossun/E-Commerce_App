using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Mvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
