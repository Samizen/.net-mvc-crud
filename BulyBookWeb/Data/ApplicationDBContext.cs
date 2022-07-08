using BulyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulyBookWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set;}
    }
}
