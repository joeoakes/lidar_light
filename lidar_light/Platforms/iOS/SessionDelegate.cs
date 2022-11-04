using System;
using ARKit;
namespace lidar_light
{
	public class SessionDelegate : ARSessionDelegate
	{
        public override void DidAddAnchors(ARSession session, ARAnchor[] anchors)
        {

            AnchorProcessor.ProcessAnchors(session, anchors);
            session.CurrentFrame.Dispose(); // disposing of frame, otherwise app lags
        }

        public override void DidUpdateAnchors(ARSession session, ARAnchor[] anchors)
        {
            AnchorProcessor.ProcessAnchors(session, anchors);
            session.CurrentFrame.Dispose(); // disposing of frame, otherwise app lags
        }
    }
}

