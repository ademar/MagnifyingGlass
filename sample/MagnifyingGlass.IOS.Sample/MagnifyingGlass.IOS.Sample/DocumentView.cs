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
			var image = UIImage.FromFile ("sample.jpg");

			var uiimage = new UIImageView (new RectangleF(new PointF(0,0),image.Size));

			uiimage.Image = image;

			AddSubview(uiimage);

			AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleHeight;

			loupe = new MagnifierView (this);
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			var point = (touches.AnyObject as UITouch).LocationInView(this);

			loupe.NotifyLoupe(point);
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			loupe.DeactivateLoupe ();
		}




	}
}

