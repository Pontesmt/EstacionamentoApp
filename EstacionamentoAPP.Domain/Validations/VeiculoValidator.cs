using EstacionamentoApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Validations
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {

        public VeiculoValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("O ID do veículo não pode ser vazio.");

            RuleFor(v => v.NomeDono)
               .NotEmpty().WithMessage("O nome do dono não pode ser vazio.")
               .Length(1, 150).WithMessage("O nome do dono deve ter entre 3 e 150 caracteres.");

            RuleFor(v => v.EmailDono)
                .NotEmpty().WithMessage("O email do dono não pode ser vazio.")
                .EmailAddress().WithMessage("O email do dono deve ser um endereço de email válido.")
                .Length(1, 150).WithMessage("O email do dono deve ter entre 3 e 150 caracteres.");

            RuleFor(v => v.Placa)
                .NotEmpty().WithMessage("A placa do veículo não pode ser vazia.")
                .Length(1, 10).WithMessage("A placa do veículo deve ter entre 1 e 10 caracteres.");

            RuleFor(v => v.HorarioEntrada)
                 .NotEmpty().WithMessage("O horário de entrada não pode ser vazio.");

            RuleFor(v => v.HorarioSaida)
                .GreaterThanOrEqualTo(v => v.HorarioEntrada)
                .When(v => v.HorarioSaida.HasValue)
                .WithMessage("O horário de saída deve ser maior ou igual ao horário de entrada.");
        }
    }
}
