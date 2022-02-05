using Microsoft.EntityFrameworkCore;
using Shopping.Models;
namespace Shopping.DAL
{
    public class Contexto: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress; database=productosDB; trusted_connection=true");
        }
        public DbSet<Products> products { get; set; }
    }
}
