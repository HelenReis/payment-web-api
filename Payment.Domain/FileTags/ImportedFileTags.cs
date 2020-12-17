using System;

namespace Payment.Domain.FileTags
{
    public class ImportedFileTags
    {
        private ImportedFileTags(string value) { Value = value; }

        public string Value { get; set; }

        public static ImportedFileTags Dtserver { get { return new ImportedFileTags("DTSERVER"); } }
    }
}
