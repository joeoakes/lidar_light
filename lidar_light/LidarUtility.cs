using System;
namespace lidar_light
{
    public static partial class LidarUtility
    {
        public static double LumenEstimate;

        public static Obstacle CurrentObstacle;
        public static partial void GetAlerts();

        public struct Obstacle
        {
            public string? ObstacleName;
            public double? Distance;

        }
    }
}

