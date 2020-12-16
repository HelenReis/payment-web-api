using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.FinancialPostingCommand.ImportFile
{
    public class ImportFileResult : IBaseResult
    {
        public bool Sucesso { get; set; }

        public string Msg { get; set; }
    }
}
