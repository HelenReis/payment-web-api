using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Service.Queries.Client.SelectClientBankAccounts;
using Payment.Service.Queries.Contract;
using System;
using System.Threading.Tasks;

namespace Payment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IQueryService<SelectClientBankAccountsParams, SelectClientBankAccountsResult> _queryService;
        private readonly ILogger<ClientController> _logger;
        public ClientController(
            ILogger<ClientController> logger,
            IQueryService<SelectClientBankAccountsParams, SelectClientBankAccountsResult> queryService)
        {
            _queryService = queryService;
            _logger = logger;
        }

        [HttpGet("{clientId:int}")]
        public async Task<ActionResult> Get(int clientId)
        {
            try
            {
                var res = await _queryService.Query(new SelectClientBankAccountsParams(clientId));
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
