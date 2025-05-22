using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class TankBiz
    {
        public string OrderCode;
        public DateTime StartTime;
        public string StartTimeStr;
        public string Name;
        public string ProductName;
        public string DateStr;
        public string TimeStr;

        public bool LastRead;
        public static int HeightType = 48;
        public double Height;

        public static int VolumeType = 53;
        public double Volume;

        public static int TempType = 61;
        public double Temp;
        public static int WeightType = 65;
        public double Weight;
        public static int MassType = 64;
        public double Mass;
        public static int DensityType = 41;
        public double Density
       ;

        public double Quantity;


    }
}
