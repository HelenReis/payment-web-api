using Microsoft.AspNetCore.Http;
using Payment.Domain.DTOs.FinancialPosting;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.FinancialPosting.InsertFinancialPosting
{
    public class InsertFinancialPostingParams : IBaseParams
    {
        public InsertFinancialPostingParams(long bankAccountId, FinancialPostingDTO financialPostingDTO)
        {
            BankAccountId = bankAccountId;
            FinancialPostingDTO = financialPostingDTO;
        }

        public long BankAccountId { get; set; }

        public FinancialPostingDTO FinancialPostingDTO { get; set; }
    }
}
