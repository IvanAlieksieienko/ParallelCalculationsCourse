using System;
using System.IO;
using PerformanceCommonLibrary.Models;

namespace LaboratoryWork2.Services
{
	public class DiskImageService : IImageService
	{
		public string Url { private get; set; }
		public string InitialDestination { get; set; }

		public DiskImageService() => this.Url = this.InitialDestination = string.Empty;

		public DiskImageService(string url, string initialDestination)
		{
			this.Url = url;
			this.InitialDestination = initialDestination;
		}

		public void Download(object destination)
		{
			if (!File.Exists(this.Url)) return;

			File.Copy(this.Url, destination.ToString(), true);
		}

		public AdditionalInfo GetAdditionalInfo()
		{
			return new AdditionalInfo("From Disk", string.Empty, string.Empty);
		}
	}
}
