using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaboratoryWork2.Services;
using PerformanceCommonLibrary.Models;
using PerformanceCommonLibrary.Services;

namespace LaboratoryWork2
{
	class Program
	{
		/// <summary>
		/// Image url for 1 var
		/// </summary>
		private const string Url = @"https://bipbap.ru/wp-content/uploads/2017/04/krasivye_kollazh_na_temu_prirody_1920x1200.jpg";
		private const string ImageOnDisk = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork2/Destination/ImageDisk.jpg";
		private const string Destination = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork2/Destination/Image1";
		private const string FinalDestination = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork2/FinalDestination/Image2";
		private const string ExcelOutputFileDestination = @"/Users/ivan/Documents/XAI/Parallel Calculations/LaboratoryWork2/ExcelOutput/Results.xlsx";

		static void Main(string[] args)
		{
			IList<IList<PerformanceInfo>> performanceInfos = new List<IList<PerformanceInfo>>()
			{
				new List<PerformanceInfo>()
				{
					GetPerformance<WebImageService>(1, (Url, Destination)),
					GetPerformance<WebImageService>(2, (Url, Destination)),
					GetPerformance<WebImageService>(4, (Url, Destination)),
					GetPerformance<WebImageService>(8, (Url, Destination)),
					GetPerformance<WebImageService>(10, (Url, Destination)),
				},
				new List<PerformanceInfo>()
				{
					GetPerformance<DiskImageService>(1, (ImageOnDisk, FinalDestination)),
					GetPerformance<DiskImageService>(2, (ImageOnDisk, FinalDestination)),
					GetPerformance<DiskImageService>(4, (ImageOnDisk, FinalDestination)),
					GetPerformance<DiskImageService>(8, (ImageOnDisk, FinalDestination)),
					GetPerformance<DiskImageService>(10, (ImageOnDisk, FinalDestination)),
				}
			};
			ExcelExportService excelExportService = new ExcelExportService(ExcelOutputFileDestination, TimeType.ms);
			excelExportService.ManageExportInfoToExcel(performanceInfos);
		}

		static PerformanceInfo GetPerformance<TImageService>(int numberOfThreads, (string From, string To) destination) where TImageService : IImageService, new()
		{
			var imageService = new TImageService();
			imageService.Url = destination.From;
			imageService.InitialDestination = destination.To;
			var threadingService = new ThreadingService(imageService);
			var performanceInfo = PerformanceService.MeasurePerformance(new Task(() => threadingService.Run(numberOfThreads)));
			performanceInfo.AdditionalInfo = FillAdditionalInfo(imageService, numberOfThreads);
			return performanceInfo;
		}

		static AdditionalInfo FillAdditionalInfo(IImageService imageService, int numberOfThreads)
		{
			return new AdditionalInfo(imageService.GetAdditionalInfo().WorksheetName, "Number of threads", numberOfThreads.ToString());
		}
	}
}
