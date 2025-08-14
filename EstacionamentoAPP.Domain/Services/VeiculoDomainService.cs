using EstacionamentoApp.Domain.Dtos;
using EstacionamentoApp.Domain.Validations;
using EstacionamentoApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EstacionamentoApp.Domain.Service
{
    public class VeiculoDomainService : IVeiculoDomainService
    {
        public CadastroVeiculoResponseDto CadastroVeiculo
               (CadastroVeiculoRequestDto request)
        {
            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                NomeDono = request.NomeDono,
                EmailDono = request.EmailDono,
                Placa = request.Placa,
                HorarioEntrada = request.HorarioEntrada
            };

            var validation = new VeiculoValidator();
            var result = validation.Validate(veiculo);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return null;

        }
    }
}
