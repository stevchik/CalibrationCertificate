using System.Collections.Generic;

namespace CalibrationCertificate.Domain
{
    public class Serie
    {
        public Serie()
        {
            Points = new List<Point>();
        }
        public string SerieType { get; set; }
        public string Description { get; set; }
        public bool? IsAscending { get; set; }

        public string XAxisKey { get; set; }
        public string YAxisKey { get; set; }

        public List<Point> Points { get; set; }


    }

}
