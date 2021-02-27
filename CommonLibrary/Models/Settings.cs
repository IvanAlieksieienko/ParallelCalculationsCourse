using System;
namespace CommonLibrary.Models
{
    public class Settings
    {
        public int MatrixSize { get; set; }
        public WayOfPopulatingData WayOfPopulatingData { get; set; }
        public Type MatrixType { get; set; }

        public Settings(int size, WayOfPopulatingData wayOfPopulatingData, Type matrixType)
        {
            this.MatrixSize = size;
            this.WayOfPopulatingData = wayOfPopulatingData;
            this.MatrixType = matrixType;
        }
    }
}
