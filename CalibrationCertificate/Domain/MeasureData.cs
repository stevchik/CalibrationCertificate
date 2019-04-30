using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class MeasureData
    {
        public MeasureData()
        {
            Channels = new List<Channel>();
        }
        public int Id { get; set; }
        public List<Channel> Channels { get; set; }
    }
}
