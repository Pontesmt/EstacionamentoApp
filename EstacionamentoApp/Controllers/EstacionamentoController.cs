using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        [Route("adicionarveiculo")]
        [HttpPost]
        public IActionResult AdicionarVeiculo()
        {
            return Ok("");
        }

        [Route("removerveiculo")]
        [HttpPost]
        public IActionResult RemoverVeiculo()
        {
            return Ok("");
        }
    }
}
