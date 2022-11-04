using System;
using ARKit;
namespace lidar_light
{
	public class ARKitManager
	{
		ARSession session;
		public ARKitManager()
		{
			var configuration = new ARWorldTrackingConfiguration
			{
				PlaneDetection = ARPlaneDetection.Vertical,
				LightEstimationEnabled = true
			};
			session = new ARSession
			{
				Delegate = new SessionDelegate()
			};
			session.Run(configuration, ARSessionRunOptions.ResetTracking);
		}
	}
}

