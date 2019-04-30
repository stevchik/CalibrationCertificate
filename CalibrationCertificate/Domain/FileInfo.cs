using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class FileInfo
    {
        public string SoftwareVersion { get; set; }
        public string Software { get; set; }
        public DateTime CreationTime { get; set; }
        public string DataFormatEdition { get; set; }
    }
}
