using Microsoft.AspNetCore.Mvc;
using Questao5.Application;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentarContaController : ControllerBase
    {
        private readonly IMovimentoService service;
        private readonly ILogger<MovimentarContaController> _logger;

        public MovimentarContaController(ILogger<MovimentarContaController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        [ProducesResponseType(typeof(OkResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<ActionResult> MovimentaConta([FromBody] MovimentoRequest movimento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var id = service.Update(movimento);

                return Ok(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}