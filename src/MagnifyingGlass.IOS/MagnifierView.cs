using System.Drawing;
using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace Xamarin.Controls
{
    public sealed class MagnifierView :UIView
    {
        public UIView ViewToMagnify;
        PointF touchPoint;
	
		NSTimer touchTimer;
		private bool loopActivated;

		public double DelayInSeconds = 0.5;
		public float Radius = 59;
		public UIImage GlassImage;
		public bool DrawGlass = true;
		public float Scale = 1.5f;
		public float OffsetX = 0.0f;
		public float OffsetY = 60.0f;
		
        public MagnifierView (UIView viewToMagnify)
        {
			Frame = new RectangleF (0, 0, Radius*2, Radius*2);

			Layer.CornerRadius = Radius;
            Layer.MasksToBounds = true;
            BackgroundColor = UIColor.White;

			GlassImage = UIImage.FromFile("loupe-hi@2x.png");

			ViewToMagnify = viewToMagnify;
        }
		
		public void SetTouchPoint (PointF pt)
        {
			//coordinates in ViewToMagnify
			touchPoint = pt;

			//coordinates in superview
			var touchPoint1 = ViewToMagnify.ConvertPointToView (pt, Superview);

			//sets the glass in position
            Center = new PointF (touchPoint1.X - OffsetX, touchPoint1.Y - OffsetY);
        }

		float GetAngle ()
		{
			var orientation = UIApplication.SharedApplication.StatusBarOrientation;

			switch (orientation) {
				case UIInterfaceOrientation.LandscapeRight:
				return (float)(Math.PI/2.0);
				case UIInterfaceOrientation.LandscapeLeft:
				return -(float)(Math.PI/2.0);
				case UIInterfaceOrientation.PortraitUpsideDown:
				return (float)Math.PI;
			}

			return 0.0f;
		}

        public override void Draw (RectangleF rect)
        {
            var context = UIGraphics.GetCurrentContext ();

			context.SaveState();
            context.TranslateCTM (1 * (Frame.Size.Width * 0.5f), 1 * (Frame.Size.Height * 0.5f));
			context.RotateCTM (GetAngle());
            context.ScaleCTM (Scale, Scale);
			//do we need to rotate touchPoint ?
            context.TranslateCTM (-1 * touchPoint.X, -1 * touchPoint.Y);

            ViewToMagnify.Layer.RenderInContext (context);

			context.RestoreState();

			if (DrawGlass) {
				GlassImage.Draw (Bounds);
			}
        }

		public void ActivateLoupe(PointF point)
		{
			if (Window!=null)
			{
				//loupe is visible
				return;
			}

			if (touchTimer!=null)
			{
				return;
			}

			touchTimer = NSTimer.CreateScheduledTimer (DelayInSeconds, this, new Selector ("addLoupe"), null, false);
			loopActivated = true;
		}

		[Export("addLoupe")]
		public void AddLoupe()
		{
			if(loopActivated)
			{
				UIApplication.SharedApplication.KeyWindow.AddSubview(this);
			}
		}

		public void NotifyLoupe(PointF point)
		{
			ActivateLoupe(point);
			UpdateLoupe(point);
		}

		public void UpdateLoupe(PointF point)
		{
			SetTouchPoint(point);
			SetNeedsDisplay();
		}

		public void DeactivateLoupe()
		{
			loopActivated = false;

			if (touchTimer != null)
			{
				touchTimer.Invalidate();
				touchTimer = null;
			}

			RemoveFromSuperview();
		}
    }
}