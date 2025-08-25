using EstacionamentoApp.Domain.Dtos;
using EstacionamentoApp.Domain.Validations;
using EstacionamentoApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoApp.Domain.Interfaces.Repositories;
using EstacionamentoApp.Domain.Services;
using EstacionamentoApp.Domain.Interface;



namespace EstacionamentoApp.Domain.Services
{
    public class VeiculoDomainService : IVeiculoDomainService
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDomainService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository ?? throw new ArgumentNullException(nameof(veiculoRepository));
        }


        public CadastroVeiculoResponseDto CadastroVeiculo
               (CadastroVeiculoRequestDto request)
        {
            var horarioEntrada = DateTime.Now;

            var veiculo = new Veiculo
            {
                Id = Guid.NewGuid(),
                NomeDono = request.NomeDono,
                EmailDono = request.EmailDono,
                Placa = request.Placa,
                HorarioEntrada = horarioEntrada,
            };

            var validation = new VeiculoValidator();
            var result = validation.Validate(veiculo);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            if (_veiculoRepository.Exists(veiculo.EmailDono))
            {
                throw new Exception("Já existe um veículo cadastrado com este email.");
            }

            _veiculoRepository.Insert(veiculo);

            var response = new CadastroVeiculoResponseDto
            {
                Id = veiculo.Id,
                NomeDono = veiculo.NomeDono,
                EmailDono = veiculo.EmailDono,
                Placa = veiculo.Placa,
                HorarioEntrada = horarioEntrada,
            };

            return response;
        }

        public RetirarVeiculoResponseDto RetirarVeiculo
                     (RetirarVeiculoRequestDto request)

        {
            var veiculo = _veiculoRepository.Find(request.EmailDono, request.Placa);
            if(veiculo == null)
               throw new Exception("Veículo não encontrado.");

            var response = new RetirarVeiculoResponseDto
            {
                Id = veiculo.Id,
                NomeDono = veiculo.NomeDono,
                EmailDono = veiculo.EmailDono,
                Placa = veiculo.Placa,              
                HoraSaida = DateTime.Now,
                
            };
            return response;
        }
    }
}
