using IronXL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopitosExercise.BusinessLogic.Interfaces
{
    public interface IExcelReader
    {
        DataTable ReadExcel(string excelFilePath, string workSheet);
    }
}
