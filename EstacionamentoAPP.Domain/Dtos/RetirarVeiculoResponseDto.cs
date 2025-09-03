using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Dtos
{
    public class RetirarVeiculoResponseDto
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string NomeDono { get; set; }
        public string EmailDono { get; set; }
        public DateTime? HoraSaida { get; set; }
        public TimeSpan TempoEstacionado { get; internal set; }
        public DateTime HorarioSaida { get; internal set; }
        public DateTimeOffset HorarioEntrada { get; internal set; }
    }
}
