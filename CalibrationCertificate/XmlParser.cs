using CalibrationCertificate.Domain;
using System.Xml.Linq;
using System.Linq;
using System;

namespace CalibrationCertificate
{
    public static class XmlParser
    {
        public static UnitUnderTest LoadUnitUnderTest(string xmlFile)
        {
            UnitUnderTest unit = new UnitUnderTest();

            XDocument document = XDocument.Load(xmlFile);

            unit.SerialNumber = document.Root.Element("SerialNumber").Value;
            unit.Type = document.Root.Element("Type").Value;
            unit.Producer = document.Root.Element("Producer").Value;
            unit.Category = document.Root.Element("Category").Value;
            unit.Quantity = document.Root.Element("Quantity").Value;
            unit.Name = document.Root.Element("Name").Value;
            unit.Status = new Status()
            {
                Rejected = bool.Parse(document.Descendants("Status").Where(d => d.Parent == document.Root).First().Element("Rejected").Value)
            };
            ParseEnvironment(unit, document);
            ParseResults(unit, document);
            ParseLaboratory(unit, document);
            ParseMeasureData(unit, document);
            ParseFileInfo(unit, document);

            return unit;
        }

        private static void ParseEnvironment(UnitUnderTest unit, XDocument document)
        {
            var equipment = from equip in document.Descendants("ReferenceEquipment")
                            select new ReferenceEquipment()
                            {
                                SerialNumber = equip.Element("SerialNumber").Value,
                                Category = equip.Element("Category").Value,
                                Type = equip.Element("Type").Value,
                                Producer = equip.Element("Producer").Value
                            };

            unit.WorkingStandard = equipment.Where(e => e.Category.Equals("working standard")).FirstOrDefault();
            unit.ChargeCalibrator = equipment.Where(e => e.Category.Equals("precision calibrator")).FirstOrDefault();

            unit.WorkingStandard.Category = "Working Standard";
            unit.WorkingStandard.CategoryGerman = "Gebrauchsnormal";

            unit.ChargeCalibrator.Category = "Charge Calibrator";
            unit.ChargeCalibrator.CategoryGerman = "Ladungskalibrator";

            var condition = from cond in document.Descendants("Condition")
                            select new Condition()
                            {
                                Scalar = new Scalar()
                                {
                                    Number = new Number()
                                    {
                                        Value = int.Parse(cond.Element("Scalar").Element("Number").Element("Value").Value),
                                        Unit = cond.Element("Scalar").Element("Number").Element("Unit").Value
                                    }
                                },
                                ValueType = cond.Element("ValueType").Value
                            };

            unit.TemperatureCondition = condition.Where(e => e.ValueType.Equals("temperature")).FirstOrDefault();
            unit.HumidityCondition = condition.Where(e => e.ValueType.Equals("humidity")).FirstOrDefault();
        }

        private static void ParseFileInfo(UnitUnderTest unit, XDocument document)
        {
            var file = document.Descendants("FileInfo").First();

            unit.FileInfo = new FileInfo()
            {
                SoftwareVersion = file.Attribute("SoftwareVersion").Value,
                Software = file.Attribute("Software").Value,
                CreationTime = DateTime.Parse(file.Attribute("CreationTime").Value),
                DataFormatEdition = file.Attribute("DataFormatEdition").Value,
            };

            unit.DocumentType = document.Descendants("DocumentType").First().Value;
        }

        private static void ParseResults(UnitUnderTest unit, XDocument document)
        {
            var results = (from result in document.Descendants("Result").Where(r => r.Parent == document.Root) select result);

            foreach (var result in results)
            {
                var r = new Result()
                {
                    Id = int.Parse(result.Element("Id").Value),
                    MeasurementProcedure = result.Element("MeasurementProcedure").Value,
                    Range = new Input()
                    {
                        Number = new Number()
                        {
                            ValueFrom = int.Parse(result.Element("Input").Element("Number").Element("ValueFrom").Value),
                            Value = int.Parse(result.Element("Input").Element("Number").Element("Value").Value),
                            Unit = result.Element("Input").Element("Number").Element("Unit").Value
                        },
                        ValueType = result.Element("Input").Element("ValueType").Value
                    }
                };

                var conditions = from cond in result.Descendants("Condition")
                                 select new Condition()
                                 {
                                     Scalar = new Scalar()
                                     {
                                         Number = new Number()
                                         {
                                             Value = int.Parse(cond.Element("Scalar").Element("Number").Element("Value").Value),
                                             Unit = cond.Element("Scalar").Element("Number").Element("Unit")?.Value
                                         }
                                     },
                                     ValueType = cond.Element("ValueType").Value
                                 };
                r.Conditions.AddRange(conditions);

                var insideResults = (from ir in results.Descendants("Result") select ir);

                foreach (var ir in insideResults)
                {
                    Scalar scalar = new Scalar()
                    {
                        Number = new Number()
                        {
                            Value = decimal.Parse(ir.Element("Scalar").Element("Number").Element("Value").Value),
                            Unit = ir.Element("Scalar").Element("Number").Element("Unit").Value
                        }
                    };

                    string type = ir.Element("ValueType").Value;

                    switch (type)
                    {
                        case "sensitivity":
                            r.SensitivityResult = scalar;
                            break;
                        case "linearity":
                            r.LinearityResult = scalar;
                            break;
                        case "hysteresis":
                            r.HysteresisResult = scalar;
                            break;
                    }
                }

                var plot = result.Element("Plot");

                r.Plot = new Plot()
                {
                    PlotType = plot.Element("PlotType").Value,
                    Title = plot.Element("Title").Value
                };

                r.Plot.XAxis = new Axis()
                {
                    Description = plot.Element("XAxis").Element("Description").Value,
                    Start = decimal.Parse(plot.Element("XAxis").Element("Start").Value),
                    End = decimal.Parse(plot.Element("XAxis").Element("End").Value),
                    Key = plot.Element("XAxis").Element("Key").Value
                };

                r.Plot.YAxis = new Axis()
                {
                    Description = plot.Element("YAxis").Element("Description").Value,
                    Start = GetDecimalOrDefault(plot.Element("YAxis").Element("Start")?.Value),
                    End = GetDecimalOrDefault(plot.Element("YAxis").Element("End")?.Value),
                    Key = plot.Element("YAxis").Element("Key").Value
                };

                var series = (from s in plot.Descendants("Serie") select s);

                foreach (var s in series)
                {
                    var serie = new Serie()
                    {
                        SerieType = s.Element("SerieType").Value,
                        Description = s.Element("Description")?.Value,
                        IsAscending = GetBooleanOrDefault(s.Element("IsAscending")?.Value),
                        XAxisKey = s.Element("XAxisKey").Value,
                        YAxisKey = s.Element("YAxisKey").Value
                    };

                    serie.Points = (from p in s.Descendants("Point")
                                    select new Point()
                                    {
                                        X = decimal.Parse(p.Element("X").Value),
                                        Y = decimal.Parse(p.Element("Y").Value)
                                    }).ToList();

                    r.Plot.Series.Add(serie);

                }

                r.Status = new Status()
                {
                    Rejected = bool.Parse(result.Element("Status").Element("Rejected").Value)
                };
                
                unit.Results.Add(r);
            }
        }

        private static void ParseMeasureData(UnitUnderTest unit, XDocument document)
        {
            var data = (from dt in document.Descendants("MeasureData") select dt);

            foreach (var dt in data)
            {
                var md = new MeasureData()
                {
                    Id = int.Parse(dt.Element("Id").Value)
                };

                var channels = (from ch in dt.Descendants("Channel") select ch);

                foreach (var ch in channels)
                {
                    var channel = new Channel()
                    {
                        Name = ch.Element("Name").Value,
                        Unit = ch.Element("Unit").Value,
                        Data = ch.Element("Data").Value
                    };

                    channel.Attributes = (from attr in ch.Descendants("Attribute")
                                          select new Domain.Attribute()
                                          {
                                              Key = attr.Element("Key").Value,
                                              Value = attr.Element("Value").Value
                                          }).ToList();
                    md.Channels.Add(channel);
                }

                unit.MeasureDatas.Add(md);

            }
        }

        private static void ParseLaboratory(UnitUnderTest unit, XDocument document)
        {
            var lab = document.Descendants("Laboratory").First();
            var addr = lab.Element("Address");

            unit.Laboratory = new Laboratory()
            {
                Company = lab.Element("Company").Value,
                Address = new Address()
                {
                    Street = addr.Element("Street").Value,
                    City = addr.Element("City").Value,
                    PostalCode = addr.Element("PostalCode").Value,
                    Country = addr.Element("Country").Value,
                },
                Technician = lab.Element("Technician").Value,
                CalibrationDate = DateTime.Parse(lab.Element("CalibrationDate").Value),
                CalibrationVersion = int.Parse(lab.Element("CalibrationVersion").Value),
                OrderId = lab.Element("OrderId").Value
            };
        }

        private static decimal? GetDecimalOrDefault(string value)
        {
            decimal d;

            if (decimal.TryParse(value, out d))
                return d;
            else
                return null;

        }

        private static bool? GetBooleanOrDefault(string value)
        {
            bool d;

            if (bool.TryParse(value, out d))
                return d;
            else
                return null;

        }
    }
}
