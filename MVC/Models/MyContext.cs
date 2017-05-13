using System.Data.Entity;

namespace MVC.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}