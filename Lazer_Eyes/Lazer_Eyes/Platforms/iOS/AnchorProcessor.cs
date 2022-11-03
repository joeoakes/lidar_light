using System;
using ARKit;

namespace Lazer_Eyes.Platforms.iOS
{
    public static class AnchorProcessor
    {
        static readonly Settings settings = Settings.Get();
        public static void ProcessAnchors(ARKit.ARSession session, ARKit.ARAnchor[] anchors)
        {
            // called when Anchors are added or updated in Session Delegate
            //Console.WriteLine("anchors being processed");
            ARAnchor obstacleAnchor = null;
            double? obstacleAnchorDistance = null;
            string? obstacleAnchorObjectType = null;
    
            //anchors.Length is always 1 ?
            foreach (ARKit.ARAnchor anchor in anchors)
            {
                if (anchor is ARKit.ARPlaneAnchor)
                {
                    double anchorDistance = GetDistanceToAnchor(session, anchor);
                    if (anchorDistance < settings.GetDistanceThreshold() && ((ARPlaneAnchor)anchor).Classification.ToString().ToLower() != "floor")
                    {
                        if (obstacleAnchor == null)
                        {
                            obstacleAnchor = anchor;
                            obstacleAnchorDistance = anchorDistance;
                            obstacleAnchorObjectType = ((ARPlaneAnchor)anchor).Classification.ToString();


                        }
                        else if (anchorDistance < obstacleAnchorDistance)
                        {
                            obstacleAnchor = anchor;
                            obstacleAnchorDistance = anchorDistance;
                            obstacleAnchorObjectType = ((ARPlaneAnchor)anchor).Classification.ToString();

                        }
                    }
                }
                else if (anchor is ARKit.ARObjectAnchor)
                {
                    continue;
                }
            }
            LidarUtils.CurrentObstacle.Distance = obstacleAnchorDistance;
            LidarUtils.CurrentObstacle.ObstacleName = obstacleAnchorObjectType;
            LidarUtils.CurrentLightEstimate = (float)session.CurrentFrame.LightEstimate.AmbientIntensity;
            //Console.WriteLine(LidarUtils.CurrentLightEstimate);

            //Console.WriteLine($"Obstacle Name: {LidarUtils.CurrentObstacle.ObstacleName}, Obstacle Distance: {LidarUtils.CurrentObstacle.Distance}");

            //System.Diagnostics.Debug.WriteLine($"Obstacle Name: {LidarUtils.CurrentObstacle.ObstacleName}, Obstacle Distance: {LidarUtils.CurrentObstacle.Distance}");
        }

        public static double GetDistanceToAnchor(ARKit.ARSession session, ARKit.ARAnchor anchor)
        {
            var cameraPosition = session.CurrentFrame.Camera.Transform.Column3;
            var anchorPosition = anchor.Transform.Column3;
            // here’s a line connecting the two points, which might be useful for other things
            var cameraToAnchor = cameraPosition - anchorPosition;
            // and here’s just the scalar distance
            var distance = cameraToAnchor.Length();
            return distance;

        }
    }
}

