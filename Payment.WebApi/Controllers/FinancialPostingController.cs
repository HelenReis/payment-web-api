using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Domain.DTOs.FinancialPosting;
using Payment.Service.Comandos.Contract;
using Payment.Service.Comandos.FinancialPosting.ImportFile;
using Payment.Service.Comandos.FinancialPosting.InsertFinancialPosting;
using Payment.Service.Comandos.FinancialPostingCommand.ImportFile;
using Payment.Service.Shared;
using System;
using System.Threading.Tasks;

namespace Payment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialPostingController : ControllerBase
    {
        private readonly ILogger<FinancialPostingController> _logger;
        private readonly ICommandService<ImportFileParams, ImportFileResult> _commandImport;
        private readonly ICommandService<InsertFinancialPostingParams, InsertFinancialPostingResult> _commandInsert;

        public FinancialPostingController(
            ILogger<FinancialPostingController> logger,
            ICommandService<ImportFileParams, ImportFileResult> commandImport,
            ICommandService<InsertFinancialPostingParams, InsertFinancialPostingResult> commandInsert)
        {
            _logger = logger;
            _commandImport = commandImport;
            _commandInsert = commandInsert;
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

                var res = await _commandImport.ExecutarComando(new ImportFileParams(clientId, file));
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("{bankAccountId:long}")]
        public async Task<ActionResult> Insert(
            long bankAccountId,
            [FromBody] FinancialPostingDTO financialPostingDTO)
        {
            try
            {
                var res = await _commandInsert.ExecutarComando(
                    new InsertFinancialPostingParams(bankAccountId, financialPostingDTO));
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
