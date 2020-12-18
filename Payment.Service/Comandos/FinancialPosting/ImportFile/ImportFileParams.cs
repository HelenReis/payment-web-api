using Microsoft.AspNetCore.Http;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.FinancialPosting.ImportFile
{
    public class ImportFileParams : IBaseParams
    {
        public ImportFileParams(int clientId, IFormFile file)
        {
            ClientId = clientId;
            File = file;
        }

        public int ClientId { get; set; }

        public IFormFile File { get; set; }
    }
}
