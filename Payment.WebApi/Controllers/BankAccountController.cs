using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Data.Repositories;
using Payment.Domain.Models;
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
        private readonly IBankAccountRepository _repository;

        private readonly ILogger<BankAccountController> _logger;

        public BankAccountController(ILogger<BankAccountController> logger, IBankAccountRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{bankAccountId:int}")]
        public async Task Get(int bankAccountId)
        {
            
        }
    }
}
