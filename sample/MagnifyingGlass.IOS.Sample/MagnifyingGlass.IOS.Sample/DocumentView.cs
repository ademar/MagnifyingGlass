using System;
using MonoTouch.UIKit;
using Xamarin.Controls;
using MonoTouch.Foundation;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace MagnifyingGlass.IOS.Sample
{
	public class DocumentView : UIView
	{
		MagnifierView loupe;

		public DocumentView (RectangleF frame):base(frame)
		{
			var image = UIImage.FromFile ("sample.jpg").CreateResizableImage(UIEdgeInsets.Zero);
			var uiimage = new UIImageView (frame);

			uiimage.Image = image;
			uiimage.AutoresizingMask = UIViewAutoresizing.All;

			AddSubview(uiimage);

			AutoresizingMask = UIViewAutoresizing.All;

			loupe = new MagnifierView (this);
			loupe.DelayInSeconds = 0.1;
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			var point = (touches.AnyObject as UITouch).LocationInView(this);

			loupe.ActivateLoupe(point);
			loupe.UpdateLoupe(point);
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			var point = (touches.AnyObject as UITouch).LocationInView(this);

			loupe.UpdateLoupe(point);
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			loupe.DeactivateLoupe ();
		}


	}
}

