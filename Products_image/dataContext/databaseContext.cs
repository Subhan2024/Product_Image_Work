using Microsoft.EntityFrameworkCore;
using Products_image.Models;

namespace Products_image.dataContext
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}
