using CopitosExercise.BusinessLogic.Interfaces;
using IronXL;
using System;
using System.Data;

namespace CopitosExercise.BusinessLogic
{
    public class ExcelReader : IExcelReader
    {
        public DataTable ReadExcel(string filePath, string workSheet)
        {
            if(string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(workSheet))
            {
                throw new ArgumentNullException("Either the filePath or the spcified worksheet was null or empty");
            }

            WorkBook excelWorkBook = WorkBook.LoadExcel(filePath);
            WorkSheet sheet = excelWorkBook.GetWorkSheet(workSheet);

            if(sheet == null)
            {
                throw new ArgumentNullException("The Worksheet could not be found");
            }

            return sheet.ToDataTable(true);
        }
    }
}
