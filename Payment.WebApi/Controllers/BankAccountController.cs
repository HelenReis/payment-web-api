using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Data.Repositories;
using Payment.Domain.DTOs;
using Payment.Domain.Models;
using Payment.Service.Comandos.BankAccount.UpdateBankAccount;
using Payment.Service.Comandos.Contract;
using Payment.Service.Queries.BankAccount.SelectBankAccount;
using Payment.Service.Queries.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IQueryService<SelectBankAccountParams, SelectBankAccountResult> _queryService;
        private readonly ICommandService<UpdateBankAccountParams, UpdateBankAccountResult> _commandService;
        private readonly ILogger<BankAccountController> _logger;

        public BankAccountController(
            ILogger<BankAccountController> logger, 
            IQueryService<SelectBankAccountParams, SelectBankAccountResult> queryService,
            ICommandService<UpdateBankAccountParams, UpdateBankAccountResult> commandService)
        {
            _logger = logger;
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet("{bankAccountId:long}")]
        public async Task<ActionResult> Get(long bankAccountId)
        {
            try
            {
                var res = await _queryService.Query(new SelectBankAccountParams(bankAccountId));
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("{bankAccountId:long}")]
        public async Task<ActionResult> Patch(long bankAccountId, BankAccountDTO bankAccountPatch)
        {
            try
            {
                var res = await _commandService.ExecutarComando(new UpdateBankAccountParams(bankAccountId, bankAccountPatch));
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
