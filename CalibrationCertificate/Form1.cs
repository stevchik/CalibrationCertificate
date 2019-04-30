using CalibrationCertificate.Domain;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace CalibrationCertificate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            this.txtSource.Text = Properties.Settings.Default.Source;
            this.txtDestination.Text = Properties.Settings.Default.Destination;

            this.txtFrom.Value = Properties.Settings.Default.PressureFrom;
            this.txtIncrement.Value = Properties.Settings.Default.PressureIncrement;
        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            //IList<DataPoint> series = new List<DataPoint>();




            using (var ch = new System.Windows.Forms.DataVisualization.Charting.Chart())
            {
                ch.ChartAreas.Add(new ChartArea());
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Total Income");


                series.ChartType = SeriesChartType.Spline;
                series.Points.AddXY("September", 100);
                series.Points.AddXY("Obtober", 300);
                series.Points.AddXY("November", 800);
                series.Points.AddXY("December", 200);
                series.Points.AddXY("January", 600);
                series.Points.AddXY("February", 400);


                ch.Series.Add(series);
                ch.SaveImage(@"C:\work\Output.jpg", ChartImageFormat.Jpeg);
            }
        }
        

      

        private void btnSource_Click(object sender, EventArgs e)
        {
            SetFolderLocation(this.txtSource);
            Properties.Settings.Default.Source = this.txtSource.Text;
            Properties.Settings.Default.Save();
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            SetFolderLocation(this.txtDestination);
            Properties.Settings.Default.Destination = this.txtDestination.Text;
            Properties.Settings.Default.Save();
        }

        private void SetFolderLocation(TextBox txt)
        {
            if (!string.IsNullOrWhiteSpace(txt.Text))
            {
                this.fbdBrowse.SelectedPath = txt.Text;
            }

            DialogResult result = this.fbdBrowse.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt.Text = this.fbdBrowse.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Add("Process Started");

            //System.IO.FileInfo xmlFile = new System.IO.FileInfo(@"C:\work\Josh\Xml\6963A_123456_25Apr2019T1551_xCert.xml");
            //UnitUnderTest unit = XmlParser.LoadUnitUnderTest(@"C:\work\Josh\Xml\6963A_123456_25Apr2019T1551_xCert.xml");

            DirectoryInfo sourceDirectory = new DirectoryInfo(txtSource.Text);
            System.IO.FileInfo[] xmlFiles = sourceDirectory.GetFiles("*.xml"); 


            foreach(System.IO.FileInfo xmlFile in xmlFiles)
            {
                lstStatus.Items.Add($"Found {xmlFile.Name} file.");
                UnitUnderTest unit = XmlParser.LoadUnitUnderTest(xmlFile.FullName);
                lstStatus.Items.Add($"Loaded contents of the {xmlFile.Name} file.");

                System.IO.FileInfo pdfFile = new System.IO.FileInfo($@"{txtDestination.Text}\\{xmlFile.Name.Replace("xml", "pdf")}");
                PdfGenerator.GeneratePdf(unit, pdfFile.FullName, Decimal.ToInt32(txtFrom.Value), Decimal.ToInt32(txtIncrement.Value));
                lstStatus.Items.Add($"Generated {pdfFile.Name} file.");
                System.Diagnostics.Process.Start(pdfFile.FullName);
            }

            
            Properties.Settings.Default.PressureFrom = Decimal.ToInt32(this.txtFrom.Value);
            Properties.Settings.Default.PressureIncrement = Decimal.ToInt32(this.txtIncrement.Value);
            Properties.Settings.Default.Save();
            lstStatus.Items.Add($"Saved defaults.");
            //System.Diagnostics.Process.Start(pdfFile.FullName);
            //Application.Exit();

        }
        
    }
}
