using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Dtos
{
    public class AutenticarVeiculoRequestDto
    {
        public string Placa { get; set; }
        public string EmailDono { get; set; }
    }
}
