using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class Axis
    {
        public string Description { get; set; }
        public Decimal? Start { get; set; }

        public Decimal? End { get; set; }

        public string Key { get; set; }
    }
}
