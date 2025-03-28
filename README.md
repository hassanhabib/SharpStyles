
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

#submit-button {
	width: "12px";
}
```

You can also customize your selectors as follows:

```csharp
public class MyComponentStyle: SharpStyle
{
	[CssElement(Selector="my-custom-td")]
	public SharpStyle Td {get; set;}
	
	[CssClass(Selector=".my-custom-primary-button")]
	public SharpStyle PrimaryButton {get; set;}

	[CssId(Selector="#my-custom-submit-button")]
	public SharpStyle SubmitButton {get; set;}
}
```

which will produce the following CSS:
```css
my-custom-td {
	background-color: "red";
}

.my-custom-primary-button {
	background-color: "blue";
	color: "white";
}

#my-custom-submit-button {
	width: "12px";
}
```

### Media Query Support
SharpStyles also supports building **CSS media queries** using C# � allowing you to write responsive styles in a testable, fluent format.

**Example Usage**

```csharp
var mediaQuery = new MediaQuery
{
    Only = true,
    MediaType = "screen",
    MaxWidth = 768,
    Styles = new SharpStyle
    {
        BackgroundColor = "red"
    }
};

string css = mediaQuery.ToCss();
```
This generates the following CSS:

```css
@media only screen and (max-width: 768px) {
	background-color: red;
}
```
You can also use additional features like min-width, not, or custom conditions such as orientation:

```csharp
var mediaQuery = new MediaQuery
{
    MediaType = "screen",
    MinWidth = 600,
    MaxWidth = 1024,
    CustomFeature = "(orientation: landscape)",
    Styles = new SharpStyle
    {
        Color = "blue"
    }
};

```
Which generates the following CSS:
```css
@media screen and (min-width: 600px) and (max-width: 1024px) and (orientation: landscape) {
  color: blue;
}
```

## Follow-up

Here's a video introduction to this library:

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/06chSzVeuls/0.jpg)](https://www.youtube.com/watch?v=06chSzVeuls)

<br />

If you have any suggestions, comments or questions, please feel free to contact me on:
<br />
Twitter: @hassanrezkhabib
<br />
LinkedIn: hassanrezkhabib
<br />
E-Mail: hassanhabib@live.com
<br />