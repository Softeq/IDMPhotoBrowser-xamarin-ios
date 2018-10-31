// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace IDMPhotoBrowserBindings
{
    public class FullScreenPhotosService
    {
        private readonly Func<UIViewController> _getTopViewControllerFunc;

        public FullScreenPhotosService(Func<UIViewController> getTopViewControllerFunc)
        {
            _getTopViewControllerFunc = getTopViewControllerFunc;
        }

        public bool IsPortraitOnly { get; set; } = true;

        public void DisplayImages(IList<string> urls, int startIndex = 0)
        {
            var photos = urls.Select(x => new IDMPhoto(new NSUrl(x))).ToArray();

            var fullScreenPhotosViewController = new FullScreenPhotosViewController(photos)
            {
                DisplayToolbar = false,
                UsePopAnimation = true,
                DisableVerticalSwipe = false, 
                DisplayDoneButton = false
            };
            fullScreenPhotosViewController.SetInitialPageIndex((uint)startIndex);
            fullScreenPhotosViewController.Delegate = new CustomIDMPhotoBrowserDelegate
            {
                IsPortraitOnly = IsPortraitOnly
            };

            _getTopViewControllerFunc()?.PresentViewController(fullScreenPhotosViewController, true, () => {});
        }

        private class CustomIDMPhotoBrowserDelegate : IDMPhotoBrowserDelegate
        {
            public bool IsPortraitOnly { get; set; }

            public override void WillDisappearPhotoBrowser(IDMPhotoBrowser controller)
            {
                if (IsPortraitOnly)
                {
                    UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromInt32((int)UIInterfaceOrientation.Portrait),
                                                          new NSString("orientation"));
                }
            }
        }
    }
}
