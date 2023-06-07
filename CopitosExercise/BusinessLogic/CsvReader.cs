using CopitosExercise.BusinessLogic.Interfaces;
using IronXL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopitosExercise.BusinessLogic
{
    public class CsvReader : ICsvReader
    {
        public DataTable ReadCsv(string csvFilePath, string workSheet)
        {
            if (string.IsNullOrEmpty(csvFilePath))
            {
                throw new ArgumentNullException("csv file path was null or empty");
            }

            WorkBook csvWorkBook = WorkBook.LoadCSV(csvFilePath, fileFormat: ExcelFileFormat.XLSX, ListDelimiter: ";");
            WorkSheet sheet = csvWorkBook.DefaultWorkSheet;

            if(sheet == null)
            {
                throw new ArgumentNullException("The specified sheet for the csv file was null");
            }

            return sheet.ToDataTable(true);
        }
    }
}
