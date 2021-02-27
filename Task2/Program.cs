using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommonLibrary.Models;
using CommonLibrary.Services;
using Task2.Models;
using Task2.Services;

namespace Task2
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
            var simpleArrayPerformanceInfo = performanceService.Manage(
                new Settings(0, WayOfPopulatingData.Row, typeof(SimpleArray)), sizesArray);
            var simpleLinkedListPerformanceInfo = performanceService.Manage(
                new Settings(0, WayOfPopulatingData.Column, typeof(SimpleLinkedList)), sizesArray);
            var simpleArrayListPerformanceInfo = performanceService.Manage(
                new Settings(0, WayOfPopulatingData.Column, typeof(SimpleArrayList)), sizesArray);

            ExcelExportService excelExportService = new ExcelExportFileService();
            IList<IList<PerformanceInfo>> listOfPerformancesLists = new List<IList<PerformanceInfo>>
            {
                simpleArrayPerformanceInfo,
                simpleLinkedListPerformanceInfo,
                simpleArrayListPerformanceInfo
            };

            excelExportService.ManageExportInfoToExcel(listOfPerformancesLists);
            Console.WriteLine("Done");
        }
    }
}
