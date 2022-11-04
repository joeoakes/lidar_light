using System;
using ARKit;
namespace lidar_light
{
    public static partial class LidarUtility
    {
        static bool running = false;
        static ARKitManager aRKitManager;

        public static partial void GetAlerts()
        {
            if (!running)
            {
                running = true;
                aRKitManager = new ARKitManager();
            }
        }
    }
}

