using System;
using Lazer_Eyes.Platforms.iOS;

namespace Lazer_Eyes
{ 
    public static partial class LidarUtils
    {
        static bool isStarted = false;
        static ARKitManager arkitManager;

        public static partial void GetAlerts()
        {
            // runs once
            if (!isStarted)
            {
                isStarted = true;
                arkitManager = new ARKitManager();
            }
            
        }
    }
}