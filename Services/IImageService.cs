using System;
using PerformanceCommonLibrary.Models;

namespace LaboratoryWork2.Services
{
	public interface IImageService
	{
		string Url { set; }
		string InitialDestination { get; set; }

		void Download(object destination);
		AdditionalInfo GetAdditionalInfo();
	}
}
