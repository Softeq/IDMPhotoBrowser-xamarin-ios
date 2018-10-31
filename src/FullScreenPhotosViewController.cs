// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using UIKit;

namespace IDMPhotoBrowserBindings
{
    public class FullScreenPhotosViewController : IDMPhotoBrowser
    {
        public FullScreenPhotosViewController(IDMPhoto[] photos) : base(photos)
        {
        }

        public override bool ShouldAutorotate()
        {
            return true;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.AllButUpsideDown;
        }
    }
}
