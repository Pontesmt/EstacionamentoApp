using EstacionamentoApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Domain.Service
{
    public interface IVeiculoDomainService
    {
        CadastroVeiculoResponseDto CadastroVeiculo
               (CadastroVeiculoRequestDto request);

    }
}
