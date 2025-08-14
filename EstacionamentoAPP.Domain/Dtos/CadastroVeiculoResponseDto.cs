using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Dtos
{
    public class CadastroVeiculoResponseDto
    {
        public Guid Id { get; set; }
        public string NomeDono { get; set; }
        public string EmailDono { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioSaida { get; set; }
    }
}
