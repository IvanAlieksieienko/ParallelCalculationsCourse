using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CommonLibrary.Models;
using OfficeOpenXml;

namespace CommonLibrary.Services
{
    public class ExcelExportService
    {
        public virtual string ExcelFilePath { get; set; }
        
        public void ManageExportInfoToExcel(IList<IList<PerformanceInfo>> performanceInfos)
        {
            if (File.Exists(ExcelFilePath))
            {
                File.Delete(ExcelFilePath);
            }
            using (var excelPackage = new ExcelPackage(new System.IO.FileInfo(ExcelFilePath)))
            {
                performanceInfos.ToList().ForEach(performanceInfo =>
                {
                    var performanceInfoSettings = performanceInfo.First().Settings;
                    var worksheetName = this.PopulateWorkSheetName(performanceInfoSettings);

                    ExcelWorksheet ws = null;
                    if (!excelPackage.Workbook.Worksheets.Any(w => w.Name == worksheetName))
                        ws = excelPackage.Workbook.Worksheets.Add(worksheetName);
                    else ws = excelPackage.Workbook.Worksheets[worksheetName];
                    this.ExportPerformanceInfoToExcel(performanceInfo, ws);
                });
                excelPackage.Save();
            }
        }

        public virtual string PopulateWorkSheetName(Settings settings)
        {
            throw new NotImplementedException();
        }

        public virtual void ExportPerformanceInfoToExcel(IList<PerformanceInfo> performanceInfos, ExcelWorksheet worksheet)
        {
            string[] headers = new string[] { "Array size", "Time spent", "Memory spend" };
            int column = 1;
            int row = 1;
            foreach (var header in headers)
            {
                worksheet.Cells[1, column++].Value = header;
            }

            row = 2;
            foreach (var performanceInfo in performanceInfos)
            {
                column = 1;
                worksheet.Cells[row, column++].Value = performanceInfo.MatrixSize;
                worksheet.Cells[row, column++].Value = performanceInfo.TimeSpent.TotalSeconds;
                worksheet.Cells[row, column++].Value = performanceInfo.KBytesSpent;
                row++;
            }
        }
    }
}
