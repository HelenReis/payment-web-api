using Microsoft.AspNetCore.Http;
using Payment.Domain.FileModels;
using Payment.Domain.FileTags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Payment.Service.Comandos.FinancialPostingCommand.ImportFile.Helper
{
    internal class ImportFileHelper
    {
        private IFormFile _file;
        private BankFile _bankFile;
        private List<FinancialPostingFile> _financialPostingFile;
        private BankAccountFile _bankAccountFile;
        private FinancialPostingFile _financial;

        public ImportFileHelper(IFormFile file)
        {
            _file = file;
            _bankFile = new BankFile();
            _financialPostingFile = new List<FinancialPostingFile>();
            _bankAccountFile = new BankAccountFile();
        }
        public async Task<(BankFile, BankAccountFile, IEnumerable<FinancialPostingFile>)> ImportFile()
        {
            string line;
            using var fs = _file.OpenReadStream();
            using var reader = new StreamReader(fs);

            while ((line = await reader.ReadLineAsync()) != null)
            {
                line = CleanTagSpaces(line);
                ReadBankData(line);
                ReadFinancialPostingData(line);
                ReadBankAccountData(line);
            }

            return (_bankFile, _bankAccountFile, _financialPostingFile);
        }

        private void ReadBankData(string line)
        {
            if (line.Contains(FileBankTags.Id.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileBankTags.Id.Value, "");
                _bankFile.IdFromFile = value;
            }

            if (line.Contains(FileBankTags.Org.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileBankTags.Org.Value, "");
                _bankFile.OrgFromFile = value;
            }
        }

        private void ReadBankAccountData(string line)
        {
            if (line.Contains(FileBankAccountTags.Id.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileBankAccountTags.Id.Value, "");
                _bankAccountFile.IdFromFile = value;
            }

            if (line.Contains(FileBankAccountTags.BankId.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileBankAccountTags.BankId.Value, "");
                _bankAccountFile.BankIdFromFile = value;
            }
        }

        private void ReadFinancialPostingData(string line)
        {
            if (line.Equals("<STMTTRN>"))
                _financial = new FinancialPostingFile();

            if (line.Contains(FileFinancialPostingTags.Dtposted.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileFinancialPostingTags.Dtposted.Value, "");
                _financial.DtpostedFromFile = value;
            }

            if (line.Contains(FileFinancialPostingTags.Fitid.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileFinancialPostingTags.Fitid.Value, "");
                _financial.FitidFromFile = value;
            }

            if (line.Contains(FileFinancialPostingTags.Memo.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileFinancialPostingTags.Memo.Value, "");
                _financial.MemoFromFile = value;
            }

            if (line.Contains(FileFinancialPostingTags.Trnamt.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileFinancialPostingTags.Trnamt.Value, "");
                _financial.TrnamtFromFile = value;
            }

            if (line.Contains(FileFinancialPostingTags.Trntype.Value))
            {
                line = CleanTag(line);
                var value = line.Replace(FileFinancialPostingTags.Trntype.Value, "");
                _financial.TrntypeFromFile = value;
            }

            if (line.Equals("</STMTTRN>"))
                _financialPostingFile.Add(_financial);
        }

        private string CleanTag(string line)
        {
            line = line.Replace("<", "");
            line = line.Replace("/", "");
            line = line.Replace(">", "");
            return line;
            //return new Regex(@"\b/([</>])+\b").Replace(line, "");
        }

        private string CleanTagSpaces(string line)
        {
            line = line.Replace(" ", "");
            return line;
            //return new Regex(@"\b/([</>])+\b").Replace(line, "");
        }
    }
}
