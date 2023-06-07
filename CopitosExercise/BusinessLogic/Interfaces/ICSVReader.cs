using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopitosExercise.BusinessLogic.Interfaces
{
    public interface ICsvReader
    {
        DataTable ReadCsv(string csvFilePath, string workSheet);
    }
}
