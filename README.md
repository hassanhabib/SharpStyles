
<p align="center">
  <img width="25%" height="25%" src="https://raw.githubusercontent.com/hassanhabib/SharpStyles/master/SharpStyles/Resources/SharpStyles.png">
</p>

# SharpStyles
TDD-able Styles for Blazor

This library offers the capability to write CSS rules in C#.
This capability allows C#.NET developers especially for Blazor applications to test-drive the CSS rules in their components effectively.


## How to Use
To use SharpStyles; all you need to do is to inherit the `SharpStyles` model to your local Component Style models as follows:

### Setup
```csharp
public class MyComponentStyle: SharpStyle
{
	[CssElement]
	public SharpStyle Td {get; set;}
	
	[CssClass]
	public SharpStyle PrimaryButton {get; set;}

	[CssId]
	public SharpStyle SubmitButton {get; set;}
}
```

Now you can use `MyComponentStyle` as follows:

```csharp
var myComponentStyle = new MyComponentStyle
{
	Td = new SharpStyle
	{
		BackgroundColor = "red"
	},

	PrimaryButton = new SharpStyle
	{
		BackgroundColor = "blue",
		Color = "white"
	},

	SubmitButton = new SharpStyle
	{
		Width = "12px"
	}
}
```

You can now use this object `myComponentStyle` to generate CSS rules for your Blazor component just as follows:

```csharp
	myComponentStyle.ToCss();
```

This code will generate the following rules:

```css
td {
	background-color: "red";
}

.primary-button {
	background-color: "blue";
	color: "white";
}

#submitButton {
	width: "12px";
}
``