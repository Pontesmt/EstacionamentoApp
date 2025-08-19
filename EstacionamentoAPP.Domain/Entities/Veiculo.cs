using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Entities
{
    public class Veiculo
    {

        public Guid Id { get; set; }
        public string NomeDono { get; set; }
        public string EmailDono { get; set; }
        public string Placa { get; set; }
        public DateTimeOffset HorarioEntrada { get; set; }
        public DateTimeOffset? HorarioSaida { get; set; }

    }
}
