using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class Result
    {
        public Result()
        {
            Conditions = new List<Condition>();
        }
        public int Id { get; set; }
        public string MeasurementProcedure { get; set; }

        public Input Range { get; set; }

        public List<Condition> Conditions { get; set; }

        public Scalar SensitivityResult { get; set; }

        public Scalar LinearityResult { get; set; }

        public Scalar HysteresisResult { get; set; }

        public Status Status { get; set; }

        public Plot Plot { get; set; }
    }
}
