using System;
using CommonLibrary.Models;
using CommonLibrary.Services;

namespace Task1.Services
{
    public class ExcelExportFileService : ExcelExportService
    {
        public override string ExcelFilePath { get; set; } = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork1/ExcelOutput/Task1Results.xlsx";

        public override string PopulateWorkSheetName(Settings settings)
        {
            string worksheetName = string.Empty;
            worksheetName = settings.MatrixType == typeof(int) ? "Int " : "Float ";
            worksheetName += settings.WayOfPopulatingData switch
            {
                WayOfPopulatingData.Column => "By Column",
                WayOfPopulatingData.Row => "By Row",
            };
            return worksheetName;
        }
    }
}
