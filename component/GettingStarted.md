`MagnifyingGlass` provides a magnifying glass or loupe effect that enlarges the graphic content under your touch.

## Example

Here is an example illustrating how to enable the magnifying glass effect on a view and the use of properties that will allow you to customize the look and behaviour of the magnifiying glass.

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

