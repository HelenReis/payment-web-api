using Microsoft.AspNetCore.Http;
using Payment.Domain.FileModels;
using Payment.Domain.FileTags;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Payment.Service.Comandos.FinancialPostingCommand.ImportFile.Helper
{
    internal class ImportFileHelper
    {
        private IFormFile _file;
        private ImportedFileFile _importedFile;
        private BankFile _bankFile;
        private List<FinancialPostingFile> _financialPostingFile;
        private BankAccountFile _bankAccountFile;
        private FinancialPostingFile _financial;

        public ImportFileHelper(IFormFile file)
        {
            _file = file;
            _importedFile = new ImportedFileFile();
            _bankFile = new BankFile();
            _financialPostingFile = new List<FinancialPostingFile>();
            _bankAccountFile = new BankAccountFile();
        }
        public async Task<(ImportedFileFile, BankFile, BankAccountFile, IEnumerable<FinancialPostingFile>)> ReadFile()
        {
            /* LER SOBRE STACK E HEAP PARA FAZER AS VALIDAÇÕES DE COLETA DA GC */
            string line;
            using var fs = _file.OpenReadStream();
            using var reader = new StreamReader(fs);

            while ((line = await reader.ReadLineAsync()) != null)
            {
                line = CleanTagSpaces(line);
                ReadFileData(line);
                ReadBankData(line);
                ReadFinancialPostingData(line);
                ReadBankAccountData(line);
            }

            return (_importedFile, _bankFile, _bankAccountFile, _financialPostingFile);
        }

        #region[Ler dados do arquivo]
        private void ReadFileData(string line)
        {
            if (line.Contains(ImportedFileTags.Dtserver.Value))
            {
                line = CleanTag(line, ImportedFileTags.Dtserver.Value);
                _importedFile.DtserverFromFile = line;
            }
        }
        #endregion

        #region[Ler dados do banco]
        private void ReadBankData(string line)
        {
            if (line.Contains(FileBankTags.Id.Value))
            {
                line = CleanTag(line, FileBankTags.Id.Value);
                _bankFile.IdFromFile = line;
            }

            if (line.Contains(FileBankTags.Org.Value))
            {
                line = CleanTag(line, FileBankTags.Org.Value);
                _bankFile.OrgFromFile = line;
            }
        }
        #endregion

        #region[Ler dados da conta bancária]
        private void ReadBankAccountData(string line)
        {
            if (line.Contains(FileBankAccountTags.Id.Value))
            {
                line = CleanTag(line, FileBankAccountTags.Id.Value);
                _bankAccountFile.IdFromFile = line;
            }

            if (line.Contains(FileBankAccountTags.BankId.Value))
            {
                line = CleanTag(line, FileBankAccountTags.BankId.Value);
                _bankAccountFile.BankIdFromFile = line;
            }

            if (line.Contains(FileBankAccountTags.TypeAccount.Value))
            {
                line = CleanTag(line, FileBankAccountTags.TypeAccount.Value);
                _bankAccountFile.TypeAccountFile = line;
            }
        }
        #endregion

        #region[Ler dados dos lançamentos financeiros]
        private void ReadFinancialPostingData(string line)
        {
            if (line.Equals(FileFinancialPostingTags.OpenTag.Value))
                _financial = new FinancialPostingFile();

            if (line.Contains(FileFinancialPostingTags.Dtposted.Value))
            {
                line = CleanTag(line, FileFinancialPostingTags.Dtposted.Value);
                _financial.DtpostedFromFile = line;
            }

            if (line.Contains(FileFinancialPostingTags.Fitid.Value))
            {
                line = CleanTag(line, FileFinancialPostingTags.Fitid.Value);
                _financial.FitidFromFile = line;
            }

            if (line.Contains(FileFinancialPostingTags.Memo.Value))
            {
                line = CleanTag(line, FileFinancialPostingTags.Memo.Value);
                _financial.MemoFromFile = line;
            }

            if (line.Contains(FileFinancialPostingTags.Trnamt.Value))
            {
                line = CleanTag(line, FileFinancialPostingTags.Trnamt.Value);
                _financial.TrnamtFromFile = line;
            }

            if (line.Contains(FileFinancialPostingTags.Trntype.Value))
            {
                line = CleanTag(line, FileFinancialPostingTags.Trntype.Value);
                _financial.TrntypeFromFile = line;
            }

            if (line.Equals(FileFinancialPostingTags.CloseTag.Value))
                _financialPostingFile.Add(_financial);
        }
        #endregion

        #region[Limpar tags e retornar apenas o valor da tag]
        private string CleanTag(string line, string tag) => new Regex($"[</>]*({tag})*").Replace(line, string.Empty);
        #endregion

        #region[Limpar caracteres especiais e espaçamentos em branco]
        private string CleanTagSpaces(string line) => new Regex(@"[\s]*").Replace(line, string.Empty);
        #endregion
    }
}
