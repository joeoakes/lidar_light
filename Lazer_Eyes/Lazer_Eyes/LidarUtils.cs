using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Lazer_Eyes
{
    public static partial class LidarUtils
    {
        public static Obstacle CurrentObstacle;
        public static partial void GetAlerts();
        public static float CurrentLightEstimate;

        public struct Obstacle
        {
            public string? ObstacleName;
            public double? Distance;
        }

    }

}
