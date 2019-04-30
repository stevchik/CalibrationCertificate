using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationCertificate.Domain
{
    public class UnitUnderTest
    {
        public UnitUnderTest()
        {
            MeasureDatas = new List<MeasureData>();
            Results = new List<Result>();
        }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public string Category { get; set; }
        public string Quantity { get; set; }
        public string Name { get; set; }
        public ReferenceEquipment WorkingStandard { get; set; }
        public ReferenceEquipment ChargeCalibrator { get; set; }
        public Condition TemperatureCondition { get; set; }
        public Condition HumidityCondition { get; set; }
        public List<Domain.Result> Results { get; set; }
        public Status Status { get; set; }
        public Laboratory Laboratory { get; set; }
        public List<MeasureData> MeasureDatas { get; set; }

        public FileInfo FileInfo { get; set; }
        public string DocumentType { get; set; }
      
        public decimal? Temperature
        {
            get
            {
                //return TemperatureCondition?.Scalar?.Number?.Value;
                var temp = TemperatureCondition;
                decimal? tempF = temp?.Scalar?.Number?.Value;

                if (temp != null && temp?.Scalar?.Number?.Unit == "°C")
                {
                    tempF = (temp?.Scalar?.Number?.Value * 9 / 5) + 32;
                }

                return tempF;
            }
        }

        public string TemperatureUnit
        {
            get
            {
                return "°F";//TemperatureCondition?.Scalar?.Number?.Unit;
            }
            
        }

        public decimal? Humidity
        {
            get
            {
                return HumidityCondition?.Scalar?.Number?.Value;
            }
        }

        public string HumidityUnit
        {
            get
            {
                return HumidityCondition.Scalar.Number.Unit;
            }
        }

        public decimal? CalibrationRange {
            get{
                return Results[0].Range?.Number?.Value;
            }
        }

        public decimal? Sensitivity {
            get {
                return Results[0].SensitivityResult?.Number?.Value;
                }
        }

        public decimal? Linerality
        {
            get
            {
                return Results[0].LinearityResult?.Number?.Value;
            }
        }

        public decimal? SensorTemperature
        {
            get
            {
                var temp = Results[0].Conditions.Where(c => c.ValueType == "temperature").FirstOrDefault();
                decimal? tempF = temp?.Scalar?.Number?.Value;

                if (temp!= null && temp?.Scalar?.Number?.Unit == "°C")
                {
                    tempF = (temp?.Scalar?.Number?.Value * 9 / 5) + 32;
                }

                return tempF;
            }
        }

        public decimal? SensitvityChange
        {
            get
            {
                return null;
            }
        }
    }
}
