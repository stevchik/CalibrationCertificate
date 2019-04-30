using System.Collections.Generic;

namespace CalibrationCertificate.Domain
{
    public class Channel
    {
        public Channel()
        {
            Attributes = new List<Attribute>();
        }
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }
        public string Data { get; set; }
        public string Unit { get; set; }
    }
}
