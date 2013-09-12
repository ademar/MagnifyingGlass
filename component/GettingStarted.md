`MagnifyingGlass` implements a magnifying glass or loupe effect that enlarges the graphic content under your touch.

## Getting Started

To start using `MagnifyingGlass` all you need to do is call its constructor with the UIView instance where the magnifiying effect will be shown.
Then to show and update the loupe's position we intercept the touches events. 

The following example illustraes how to enable the magnifying glass effect on a view and demostrates the uses of a number of properties to customize the look and feel of the magnifiying glass effect.

```csharp
using Xamarin.Controls;
...

class MyView : UIView 
{
	MagnifierView loupe;

	public MyView ()
	{
		//in the constructor we pass the View we will be doing the effect on
		loupe = new MagnifierView (this);
		
		//how long shall the user press before showing the loupe
		loupe.DelayInSeconds = 0.1;
		
		//scale of magnification
		loupe.Scale = 2.0f;
		
		//glass radius
		loupe.Radius = 59;
		
		//use a different image for the loupe
		loupe.GlassImage = UIImage.FromFile("loupe.png");
		
		//position of the loupe with respect to the touch point
		loupe.OffsetX = 0.0f;
		loupe.OffsetY = 60.0f;
		
		//to show or not the glass image, by default is true
		loupe.Draw = true;
	}

	public override void TouchesBegan (NSSet touches, UIEvent evt)
	{
		var point = (touches.AnyObject as UITouch).LocationInView(this);
		//when the touches begin we notify the component that the loupe is about to show
		loupe.NotifyLoupe(point);
	}

	public override void TouchesMoved (NSSet touches, UIEvent evt)
	{
		var point = (touches.AnyObject as UITouch).LocationInView(this);
		//update the loupe position as the touches move
		loupe.UpdateLoupe(point);
	}

	public override void TouchesEnded (NSSet touches, UIEvent evt)
	{
		//hide the loupe
		loupe.DeactivateLoupe ();
	}
}
```

