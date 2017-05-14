using System;
using System.Configuration;
using System.Data.Entity;

namespace MVC.Models
{
    public class MyContext : DbContext, IDisposable
    {
        public MyContext()
            :base(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString)
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}