`MagnifyingGlass` displays a magnifying glass or loupe.

## iOS Example

```csharp
using Xamarin.Controls;
...

class MyView : UIView 
{
	MagnifierView loupe;

	public MyView ()
	{
		loupe = new MagnifierView (this);
		loupe.DelayInSeconds = 0.1;
	}

	public override void TouchesBegan (NSSet touches, UIEvent evt)
	{
		var point = (touches.AnyObject as UITouch).LocationInView(this);

		loupe.NotifyLoupe(point);
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
```

