using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MagnifyingGlass.IOS.Sample
{
	public partial class MagnifyingGlass_IOS_SampleViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MagnifyingGlass_IOS_SampleViewController ()
			: base (UserInterfaceIdiomIsPhone ? "MagnifyingGlass_IOS_SampleViewController_iPhone" : "MagnifyingGlass_IOS_SampleViewController_iPad", null)
		{
			//AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleHeight;
		}

		DocumentView documentView;

		public override void ViewWillAppear (bool animated)
		{
			var frame = UIScreen.MainScreen.Bounds;
			documentView = new DocumentView (frame);
			View.AddSubview(documentView);

			base.ViewWillAppear (animated);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
	}
}

