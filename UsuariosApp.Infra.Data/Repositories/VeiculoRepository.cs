using EstacionamentoApp.Domain.Entities;
using EstacionamentoApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoApp.Infra.Data.Contexts;


namespace EstacionamentoApp.Infra.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        public void Insert(Veiculo veiculo)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(veiculo);
                dataContext.SaveChanges();
            }
        }

        public Veiculo? Find(string email, string placa)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Veiculo>()
                .Where(v => v.EmailDono.Equals(email)
                               && v.Placa.Equals(placa))
                .FirstOrDefault();

            }
        }

        public bool Exists(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Veiculo>()
                .Any(v => v.EmailDono.Equals(email));
            }
        }

        public Veiculo? Find(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Veiculo>()
                    .Where(v => v.EmailDono.Equals(email))
                    .FirstOrDefault();
            }
        }
    }
}


