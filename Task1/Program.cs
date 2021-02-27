using System;
using System.Collections.Generic;
using CommonLibrary.Models;
using CommonLibrary.Services;
using Task1.Models;
using Task1.Services;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sizes = new List<int>();
            var min = 0;
            var max = 12000;
            var step = 50;
            for (int i = min; i <= max; i += step) sizes.Add(i);
            CommonLibrary.Services.PerformanceService performanceService = new Services.PerformanceService();
            var sizesArray = sizes.ToArray();
            var intPerformancesByRow = performanceService.Manage(new Settings(0, WayOfPopulatingData.Row, typeof(int)), sizesArray);
            var intPerformancesByColumn = performanceService.Manage(new Settings(0, WayOfPopulatingData.Column, typeof(int)), sizesArray);

            var floatPerformancesByRow = performanceService.Manage(new Settings(0, WayOfPopulatingData.Row, typeof(float)), sizesArray);
            var floatPerformancesByColumn = performanceService.Manage(new Settings(0, WayOfPopulatingData.Column, typeof(float)), sizesArray);

            ExcelExportService excelExportService = new ExcelExportFileService();
            IList<IList<PerformanceInfo>> listOfPerformancesLists = new List<IList<PerformanceInfo>>
            {
                intPerformancesByRow,
                intPerformancesByColumn,
                floatPerformancesByRow,
                floatPerformancesByColumn
            };

            excelExportService.ManageExportInfoToExcel(listOfPerformancesLists);
            Console.WriteLine("Done");
        }
    }
}
