using System;
using ARKit;
namespace lidar_light
{
	public static class AnchorProcessor
	{
		static readonly Settings settings = Settings.Get();

		public static void ProcessAnchors( ARKit.ARSession session, ARKit.ARAnchor[] anchors)
		{
			ARAnchor obstacleAnchor = null;
			double? obstacleAnchorDistance = null;
			string? obstacleAnchorObjectType = null;
			
			foreach (ARAnchor anchor in anchors)
			{
				double anchorDistance = GetDistanceToAnchor(session, anchor);
				if (anchorDistance < settings.GetDistanceThreshold())
				{
					if (obstacleAnchor == null)
					{
						obstacleAnchor = anchor;
						obstacleAnchorDistance = anchorDistance;
						obstacleAnchorObjectType = ((ARPlaneAnchor)anchor).Classification.ToString();
						Console.WriteLine(obstacleAnchorObjectType + " - " + obstacleAnchorDistance.ToString());
					}
				}
			}

			LidarUtility.CurrentObstacle.Distance = obstacleAnchorDistance;
			LidarUtility.CurrentObstacle.ObstacleName = obstacleAnchorObjectType;

			LidarUtility.LumenEstimate = (float)session.CurrentFrame.LightEstimate.AmbientIntensity;
			//Console.WriteLine($"\n" +
			//	$"Obstacle: {LidarUtility.CurrentObstacle.ObstacleName}\n " +
			//	$"Distance: {LidarUtility.CurrentObstacle.Distance}\n " +
			//	$"Lumens: {LidarUtility.LumenEstimate}\n");



		}

		public static double GetDistanceToAnchor(ARKit.ARSession session, ARKit.ARAnchor anchor)
		{
			var cameraPosition = session.CurrentFrame.Camera.Transform.Column3;
			var anchorPosition = anchor.Transform.Column3;
			var cameraToAnchor = cameraPosition - anchorPosition;
			return cameraToAnchor.Length();
		}
	}
}

