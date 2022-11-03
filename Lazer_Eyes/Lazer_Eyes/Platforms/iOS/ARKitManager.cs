using System;
using ARKit;
namespace Lazer_Eyes.Platforms.iOS
{
    public class ARKitManager
    {
        ARSession session;
        public ARKitManager()
        {

            // Create a session configuration
            var configuration = new ARWorldTrackingConfiguration
            {

                PlaneDetection = ARPlaneDetection.Vertical,
                LightEstimationEnabled = true,
                UserFaceTrackingEnabled = true
            };
            
            session = new ARSession
            {
                Delegate = new SessionDelegate()
            };
            session.Run(configuration, ARSessionRunOptions.ResetTracking);

        }

        /*public async void GetAnchors()
        {
            
            Task<ARWorldMap> maptask = session.GetCurrentWorldMap();
            wait maptask;
            ARWorldMap map = maptask.Result;
            ARAnchor[] anchors = map.Anchors;
        }*/
    }

    private class func referenceObjects(
    inGroupNamed name: String,
    bundle: Bundle?
) -> Set<ARReferenceObject>?
}

