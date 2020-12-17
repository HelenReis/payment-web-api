using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.FinancialPostingCommand.ImportFile
{
    public class ImportFileResult : IBaseResult
    {
        public ImportFileResult(bool sucesso, string msg)
        {
            Sucesso = sucesso;
            Msg = msg;
        }

        public bool Sucesso { get; set; }

        public string Msg { get; set; }
    }
}
