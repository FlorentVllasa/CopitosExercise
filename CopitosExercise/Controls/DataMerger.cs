using CopitosExercise.BusinessLogic;
using CopitosExercise.BusinessLogic.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CopitosExercise.Views.Controls
{
    public partial class DataMerger : UserControl
    {
        public string ExcelPath { get; set; }
        public string CsvPath { get; set; }
        public string PdfExportPath { get; set; }
        public IExcelReader ExcelReader { get; set; }
        public ICsvReader CsvReader { get; set; }

        public DataMerger()
        {
            InitializeComponent();
            SetDialogProperties();
            ExcelReader = new ExcelReader();
            CsvReader = new CsvReader();
        }

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {
            if(this.dlgExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelPath = this.dlgExcel.FileName;
                btnIconExcel.Image = Properties.Resources.green_tick;
            }
        }

        private void btnUploadCsv_Click(object sender, EventArgs e)
        {
            if (this.dlgCsv.ShowDialog() == DialogResult.OK)
            {
                CsvPath = this.dlgCsv.FileName;
                btnIconCsv.Image = Properties.Resources.green_tick;
            }
        }

        private void SetDialogProperties()
        {
            dlgExcel.InitialDirectory = @"C:\";
            dlgExcel.Filter = "Excel Files|*.xls;";

            dlgCsv.InitialDirectory = @"C:\";
            dlgCsv.Filter = "CSV Files|*.csv;";

            dlgSavePdf.InitialDirectory = @"C:\";
            dlgSavePdf.Filter = "PDF(*.pdf)|*.pdf";
        }

        private void btnMergeData_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ExcelPath) || string.IsNullOrEmpty(CsvPath))
            {
                MessageBox.Show("Bitte sowohl die Excel als auch die CSV-Datei hochladen");
                return;
            }

            try
            {
                DataTable excelData = ExcelReader.ReadExcel(ExcelPath, "PSt");
                DataTable csvData = CsvReader.ReadCsv(CsvPath, "Einkäufe");

                var mergeResult = from excelTable in excelData.AsEnumerable()
                             join csvTable in csvData.AsEnumerable() 
                             on excelTable["Kartennummer"] equals csvTable["Kartennummer"]
                             select new
                             {
                                 Name = excelTable["Name"],
                                 Vorname = excelTable["Vorname"],
                                 Straße = excelTable["Straße"],
                                 Hausnummer = excelTable["Hausnummer"],
                                 PLZ = excelTable["PLZ"],
                                 Ort = excelTable["Ort"],
                                 Land = excelTable["Land"],
                                 Kartennummer = excelTable["Kartennummer"],
                                 Betrag = csvTable["Betrag"]
                             };

                var bindingSource = new BindingSource();
                bindingSource.DataSource = mergeResult;
                grdMergedData.DataSource = bindingSource;

            }
            catch (System.IO.IOException ioException)
            {
                MessageBox.Show("Bitte alle hochgeladenen Dateien schließen.");
                Console.WriteLine(ioException.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten. Bitte kontaktieren Sie den Support.");
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgSavePdf.ShowDialog() == DialogResult.OK)
                {
                    PdfExportPath = dlgSavePdf.FileName;
                    PdfPTable pdfTable = new PdfPTable(grdMergedData.ColumnCount);

                    List<PdfPCell> cellList = new List<PdfPCell>()
                    {
                        new PdfPCell(new iTextSharp.text.Phrase("Name")),
                        new PdfPCell(new iTextSharp.text.Phrase("Vorname")),
                        new PdfPCell(new iTextSharp.text.Phrase("Kartennummer")),
                        new PdfPCell(new iTextSharp.text.Phrase("Betrag Netto")),
                        new PdfPCell(new iTextSharp.text.Phrase("Betrag Brutto")),
                    };

                    foreach(PdfPCell cell in cellList)
                    {
                        pdfTable.AddCell(cell);
                    }

                    foreach(DataGridViewRow row in grdMergedData.Rows)
                    {
                        foreach(DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }
                        
                    using(FileStream stream = new FileStream(PdfExportPath + ".pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                    }
                    
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            ExcelPath = null;
            CsvPath = null;
            PdfExportPath = null;
            grdMergedData.DataSource = null;
            btnIconExcel.Image = Properties.Resources.error;
            btnIconCsv.Image = Properties.Resources.error;
        }
    }
}
