using Microsoft.AspNetCore.Http;
using FluentValidation;
using EstacionamentoApp.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using EstacionamentoApp.Domain.Services;
using EstacionamentoApp.Domain.Interface;


namespace EstacionamentoApp.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoDomainService _veiculoDomainService;

        public VeiculoController(IVeiculoDomainService veiculoDomainService)
        {
            _veiculoDomainService = veiculoDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CadastroVeiculoResponseDto), 201)]
        public IActionResult AdicionarVeiculo([FromBody] CadastroVeiculoRequestDto request)
        {
            try
            {
                return StatusCode(201, _veiculoDomainService.CadastroVeiculo(request));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors.Select(e => e.ErrorMessage));
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("Retirar")]
        [HttpPost]
        [ProducesResponseType(typeof(RetirarVeiculoResponseDto), 200)]
        public IActionResult AutenticarVeiculo([FromBody] RetirarVeiculoRequestDto request)
        {
            try
            {
                return StatusCode(200, _veiculoDomainService.RetirarVeiculo(request));
            }
            catch (ValidationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch (ApplicationException e)
            {
                return StatusCode(500, new { e.Message });
            }

        }
    }
}

