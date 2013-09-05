`MagnifyingGlass` displays a magnifiying glass or loupe.

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
```

