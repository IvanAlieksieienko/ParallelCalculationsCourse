using System;
using System.Threading;

namespace LaboratoryWork2.Services
{
	public class ThreadingService
	{
		private IImageService imageService { get; set; }

		public ThreadingService(IImageService imageService) => this.imageService = imageService;

		public void Run(int numberOfThreads)
		{
			for (int i = 0; i < numberOfThreads; i++)
			{
				var destination = this.imageService.InitialDestination + Guid.NewGuid() + ".jpg";
				Thread thread = new Thread(new ParameterizedThreadStart(this.imageService.Download));
				thread.Start(destination);
			}
		}
	}
}
