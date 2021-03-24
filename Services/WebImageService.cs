using System;
using System.Drawing;
using System.IO;
using System.Net;
using PerformanceCommonLibrary.Models;

namespace LaboratoryWork2.Services
{
	public class WebImageService : IImageService
	{
		public string Url { private get; set; }
		public string InitialDestination { get; set; }

		public WebImageService() => this.Url = this.InitialDestination = string.Empty;

		public WebImageService(string url, string initialDestination)
		{
			this.Url = url;
			this.InitialDestination = initialDestination;
		}

		public void Download(object destination)
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.DownloadFile(new Uri(this.Url), destination.ToString());
			}
		}

		public AdditionalInfo GetAdditionalInfo()
		{
			return new AdditionalInfo("From Web", string.Empty, string.Empty);
		}
	}
}
