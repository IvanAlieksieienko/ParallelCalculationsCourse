using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CommonLibrary.Models;
using CommonLibrary.Services;
using OfficeOpenXml;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelExportFileService excelExportFileService = new ExcelExportFileService();
            IList<PerformanceInfo> performanceInfos = new List<PerformanceInfo>();
            HashSet1 hashSet1 = new HashSet1();
            HashSet2 hashSet2 = new HashSet2();
            Task task1 = new Task(() => hashSet1.Method());
            Task task2 = new Task(() => hashSet2.Method());
            performanceInfos.Add(PerformanceService.MeasurePerformance(task1));
            performanceInfos.Add(PerformanceService.MeasurePerformance(task2));
            if (File.Exists(excelExportFileService.ExcelFilePath)) File.Delete(excelExportFileService.ExcelFilePath);
            using (var excelPackage = new ExcelPackage(new System.IO.FileInfo(excelExportFileService.ExcelFilePath)))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(excelExportFileService.PopulateWorkSheetName(null));
                excelExportFileService.ExportPerformanceInfoToExcel(performanceInfos, worksheet);
                excelPackage.Save();
            }
        }

        class HashSet1
        {
            private HashSet<int> hashSet;

            public HashSet1()
            {
                this.hashSet = new HashSet<int>();
                for (int i = 0; i < 10_000_000; i++) this.hashSet.Add(i);
            }

            public void Method()
            {
                for (int i = 0; i < 10_000_000; i++) this.hashSet.Contains(i);
            }
        }

        class HashSet2
        {
            private HashSet<int> hashSet;
            private const int number = 0;

            public HashSet2()
            {
                this.hashSet = new HashSet<int>();
                for (int i = 0; i < 10_000_000; i++) this.hashSet.Add(i);
            }

            public void Method()
            {
                for (int i = 0; i < 10_000_000; i++) this.hashSet.Contains(number);
            }
        }
    }

    public class ExcelExportFileService : ExcelExportService
    {
        public override string ExcelFilePath { get; set; } = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork1/ExcelOutput/Task3Results.xlsx";

        public override string PopulateWorkSheetName(Settings settings)
        {
            string worksheetName = "Hash Set Performance";
            return worksheetName;
        }

        public override void ExportPerformanceInfoToExcel(IList<PerformanceInfo> performanceInfos, ExcelWorksheet worksheet)
        {
            string[] headers = new string[] { "Case Number", "Time spent"};
            int column = 1;
            int row = 1;
            foreach (var header in headers)
            {
                worksheet.Cells[1, column++].Value = header;
            }

            row = 2;
            column = 1;
            worksheet.Cells[row, column++].Value = "1";
            worksheet.Cells[row++, column++].Value = performanceInfos[0].TimeSpent.TotalSeconds;
            column = 1;
            worksheet.Cells[row, column++].Value = "2";
            worksheet.Cells[row, column++].Value = performanceInfos[1].TimeSpent.TotalSeconds;
        }
    }
}
