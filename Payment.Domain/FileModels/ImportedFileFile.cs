using System;
using System.Globalization;

namespace Payment.Domain.FileModels
{
    public class ImportedFileFile
    {
        public DateTime Dtserver
        {
            get
            {
                var date = DtserverFromFile.AsSpan().Slice(0, 14);
                var formatInfo = CultureInfo.InvariantCulture;
                DateTime.TryParseExact(date, "yyyyMMddHHmmss", formatInfo, DateTimeStyles.None, out var dateParsed);
                return dateParsed;
            }
        }

        public string DtserverFromFile { get; set; }
    }
}
