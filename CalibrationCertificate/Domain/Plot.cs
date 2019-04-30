using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class Plot
    {
        public Plot()
        {
            Series = new List<Serie>();
        }
        public string Title { get; set; }
        public string PlotType { get; set; }

        public Axis XAxis { get; set; }

        public Axis YAxis { get; set; }

        public List<Serie> Series { get; set; }
    }
}
