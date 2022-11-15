// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using IDMPhotoBrowserBindings;
using UIKit;
using Foundation;
using System.Linq;

namespace IDMPhotoBrowserSamples;

public partial class ViewController : UIViewController
{
    protected ViewController(IntPtr handle) : base(handle) { }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        var imageUrls = new[]
        {
            "https://farm4.static.flickr.com/3567/3523321514_371d9ac42f_b.jpg",
            "https://farm4.static.flickr.com/3629/3339128908_7aecabc34b_b.jpg",
            "https://farm4.static.flickr.com/3364/3338617424_7ff836d55f_b.jpg",
            "https://farm4.static.flickr.com/3590/3329114220_5fbc5bc92b_b.jpg"
        };

        var photos = imageUrls.Select(imageUrl => new IDMPhoto(NSUrl.FromString(imageUrl))).ToArray();
        var browser = new IDMPhotoBrowser(photos);

        OpenBrowserBtn.TouchUpInside += (sender, e) =>
        {
            PresentViewController(browser, true, () => { });
        };
    }
}
