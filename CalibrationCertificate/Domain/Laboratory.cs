using System;

namespace CalibrationCertificate.Domain
{
    public class Laboratory
    {
        public string Company { get; set; }
        public Address Address { get; set; }

        public string Technician { get; set; }
        public DateTime CalibrationDate { get; set; }
        public int CalibrationVersion { get; set; }
        public string OrderId { get; set; }
    }
}
