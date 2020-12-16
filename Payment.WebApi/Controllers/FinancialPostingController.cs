using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Service.Comandos.Contract;
using Payment.Service.Comandos.FinancialPostingCommand.ImportFile;
using System;
using System.Threading.Tasks;

namespace Payment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialPostingController : ControllerBase
    {
        private readonly ILogger<FinancialPostingController> _logger;
        private readonly ICommandService<ImportFileParams, ImportFileResult> _command;

        public FinancialPostingController(
            ILogger<FinancialPostingController> logger,
            ICommandService<ImportFileParams, ImportFileResult> command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpPost("file/import/{clientId:int}")]
        public async Task<ActionResult> Import(int clientId)
        {
            try
            {
                var file = Request?.Form.Files[0];

                if (!(file.Length > 0))
                    return NoContent();

                if (file is null)
                    return NoContent();

                var res = await _command.ExecutarComando(new ImportFileParams(clientId, file));
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
