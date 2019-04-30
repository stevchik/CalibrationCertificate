using CalibrationCertificate.Domain;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CalibrationCertificate
{
    public static class PdfGenerator
    {
        private static decimal PCI_CONVERTER = 14.504M;
        public static void GeneratePdf(UnitUnderTest unit, string fileName, int pressureFrom, int pressureIncrement)
        {
            LocalReport report = new LocalReport();
            //report.ReportPath = "Certificate.rdlc";
            report.ReportEmbeddedResource = "CalibrationCertificate.Reports.Certificate.rdlc";

            ReportDataSource unitDataSource = new ReportDataSource();
            unitDataSource.Name = "UnitUnderTest";
            unitDataSource.Value = new List<UnitUnderTest>() { unit };

            ReportDataSource laboratoryDataSource = new ReportDataSource();
            laboratoryDataSource.Name = "Laboratory";
            laboratoryDataSource.Value = new List<Laboratory>() { unit.Laboratory };

            ReportDataSource equipmentDataSource = new ReportDataSource();
            equipmentDataSource.Name = "Equipment";
            equipmentDataSource.Value = new List<ReferenceEquipment>() { unit.WorkingStandard, unit.ChargeCalibrator };

            List<Domain.Point> points = GetPoints(unit.Results[0].Plot.Series[0].Points, pressureFrom, pressureIncrement);

            ReportDataSource pointsDataSource = new ReportDataSource();
            pointsDataSource.Name = "Points";
            pointsDataSource.Value = points;

            ReportDataSource points1DataSource = new ReportDataSource();
            points1DataSource.Name = "Points1";
            points1DataSource.Value = points.GetRange(0, 10);

            ReportDataSource points2DataSource = new ReportDataSource();
            points2DataSource.Name = "Points2";
            points2DataSource.Value = points.GetRange(10, 10);

            ReportDataSource points3DataSource = new ReportDataSource();
            points3DataSource.Name = "Points3";
            points3DataSource.Value = points.GetRange(20, 10);

            ReportDataSource points4DataSource = new ReportDataSource();
            points4DataSource.Name = "Points4";
            points4DataSource.Value = points.GetRange(30, 10);

            report.DataSources.Add(unitDataSource);
            report.DataSources.Add(laboratoryDataSource);
            report.DataSources.Add(equipmentDataSource);

            report.DataSources.Add(pointsDataSource);
            report.DataSources.Add(points1DataSource);
            report.DataSources.Add(points2DataSource);
            report.DataSources.Add(points3DataSource);
            report.DataSources.Add(points4DataSource);

            byte[] bytes = report.Render("PDF");
            using (FileStream fs = File.Create(fileName))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        private static List<Domain.Point> GetPoints(List<Domain.Point> list, int pressureFrom, int pressureIncrement)
        {
            var response = new List<Domain.Point>();
            decimal plan = pressureFrom;

            decimal real = 0;
            decimal realPrev;

            Domain.Point point = null;
            Domain.Point pointPrev = null;

            foreach (var p in list)
            {
                realPrev = real;
                pointPrev = point;

                point = p;
                real = point.X * PCI_CONVERTER;

                if (realPrev <= plan && plan < real)
                {
                    //at this point Plan is between previous point and point
                    response.Add(new Domain.Point()
                    {
                        X = plan,
                        Y = ((plan - realPrev) / (real - realPrev)) * (point.Y - pointPrev.Y) + pointPrev.Y
                    });

                    plan = plan + pressureIncrement;

                }

            }

            return response.GetRange(0,40);
        }

    }
}
