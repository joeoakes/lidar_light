using System;
using ARKit;

namespace Lazer_Eyes.Platforms.iOS
{
    public class SessionDelegate : ARSessionDelegate
    {
        public override void DidAddAnchors(ARKit.ARSession session, ARKit.ARAnchor[] anchors)
        {
            //Console.WriteLine("anchors added ----------------");
            AnchorProcessor.ProcessAnchors(session, anchors);
        }
        public override void DidUpdateAnchors(ARKit.ARSession session, ARKit.ARAnchor[] anchors)
        {
            //Console.WriteLine("anchors updated");
            AnchorProcessor.ProcessAnchors(session, anchors);
        }
        public override void DidUpdateFrame(ARSession session, ARFrame frame)
        {
            //Console.WriteLine("frame updated");
            //base.DidUpdateFrame(session, frame);
            //Console.WriteLine(frame);
            AnchorProcessor.ProcessAnchors(session, frame.Anchors);
            frame.Dispose();
            
        }
    }
}

