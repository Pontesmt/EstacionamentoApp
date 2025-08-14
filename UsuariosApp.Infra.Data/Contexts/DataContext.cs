using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoApp.Infra.Data.Mappings;

namespace EstacionamentoApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring
             (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)" +
                "\\MSSQLLocalDB;Initial Catalog=EstacionamentoApp;" +
                "Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new EstacionamentoMap());

        }

    }
}
