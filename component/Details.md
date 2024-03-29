`MagnifyingGlass` implements a magnifying glass or loupe effect that enlarges the graphic content under your touch.

## Example

Here is a short example illustrating how simple it is to enable the magnifying glass effect on a view.

```csharp
using CodeMaker.Controls;
...

class MyView : UIView 
{
	MagnifierView loupe;

	public MyView ()
	{
		//in the constructor we pass the View we will be doing the effect on
		loupe = new MagnifierView (this);
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
