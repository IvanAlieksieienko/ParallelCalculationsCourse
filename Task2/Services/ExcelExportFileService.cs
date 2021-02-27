using System;
using CommonLibrary.Models;
using CommonLibrary.Services;
using Task2.Models;

namespace Task2.Services
{
    public class ExcelExportFileService : ExcelExportService
    {
        public override string ExcelFilePath { get; set; } = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork1/ExcelOutput/Task2Results.xlsx";

        public override string PopulateWorkSheetName(Settings settings)
        {
            string worksheetName = string.Empty;
            worksheetName = settings.MatrixType == typeof(SimpleArray) ? "double[] " :
                            settings.MatrixType == typeof(SimpleArrayList) ? "ArrayList" : "LinkedList=";
            return worksheetName;
        }
    }
}
