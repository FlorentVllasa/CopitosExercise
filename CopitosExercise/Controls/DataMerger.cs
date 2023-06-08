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

        public int SelectedCell;

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

                if (!CheckExcelFormat(excelData))
                {
                    MessageBox.Show("Das Format der Excel stimmt nicht");
                    return;
                }

                if (!CheckCsvFormat(csvData))
                {
                    MessageBox.Show("Das Format der Csv stimmt nicht");
                    return;
                }

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

                DataTable mergedTable = new DataTable();
                mergedTable.Columns.Add("Name");
                mergedTable.Columns.Add("Vorname");
                mergedTable.Columns.Add("Straße");
                mergedTable.Columns.Add("Hausnummer");
                mergedTable.Columns.Add("PLZ");
                mergedTable.Columns.Add("Ort");
                mergedTable.Columns.Add("Land");
                mergedTable.Columns.Add("Kartennummer").ReadOnly = true;
                mergedTable.Columns.Add("Betrag").ReadOnly = true;

                foreach (var item in mergeResult)
                {
                    mergedTable.Rows.Add(item.Name, item.Vorname, item.Straße, item.Hausnummer, item.PLZ, item.Ort, item.Land, item.Kartennummer, item.Betrag);
                }

                grdMergedData.DataSource = mergedTable;

            }
            catch (IOException ioException)
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

        public bool CheckExcelFormat(DataTable excelData)
        {
            List<string> columnNames = new List<string>()
            {
                "Name","Vorname","Straße", "Hausnummer", "PLZ", "Ort", "Land", "Kartennummer"
            };

            foreach(var column in columnNames)
            {
                if (!excelData.Columns.Contains(column))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckCsvFormat(DataTable csvData)
        {
            List<string> columnNames = new List<string>()
            {
                "Betrag","Kartennummer"
            };

            foreach (var column in columnNames)
            {
                if (!csvData.Columns.Contains(column))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            if(grdMergedData.ColumnCount == 0)
            {
                MessageBox.Show("Bitte zuerst die Dateien hochladen und danach die Dateien zusammenführen.");
                return;
            }

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

        private void grdMergedData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCell = e.RowIndex;
        }

        private void grdMergedData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            grdMergedData.CellValueChanged -= grdMergedData_CellValueChanged;

            DataGridViewColumn changedUserNameColumn = new DataGridViewColumn();
            changedUserNameColumn.HeaderText = "Windowsname";
            changedUserNameColumn.Name = "Windowsname";
            changedUserNameColumn.CellTemplate = new DataGridViewTextBoxCell();
            changedUserNameColumn.ReadOnly = true;

            DataGridViewColumn changedTimestamp = new DataGridViewColumn();
            changedTimestamp.HeaderText = "Aktuelles Datum";
            changedTimestamp.Name = "Aktuelles Datum";
            changedTimestamp.CellTemplate = new DataGridViewTextBoxCell();
            changedTimestamp.ReadOnly = true;

            if (!grdMergedData.Columns.Contains("Windowsname"))
            {
                grdMergedData.Columns.Add(changedUserNameColumn);
            }

            if (!grdMergedData.Columns.Contains("Aktuelles Datum"))
            {
                grdMergedData.Columns.Add(changedTimestamp);
            }

            var rowIndex = SelectedCell;

            grdMergedData.Rows[rowIndex].Cells[9].Value = Environment.UserName;
            grdMergedData.Rows[rowIndex].Cells[10].Value = DateTime.Now;

            grdMergedData.CellValueChanged += grdMergedData_CellValueChanged;
        }
    }
}
