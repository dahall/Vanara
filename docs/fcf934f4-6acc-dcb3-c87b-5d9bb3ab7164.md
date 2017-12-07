# VisualStylesRendererExtension.GetBackgroundBitmap Method 
 

Gets the background image of the current visual style element within the specified background color. If *states* is set, the resulting image will contain each of the state images side by side.

**Namespace:**&nbsp;<a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static Bitmap GetBackgroundBitmap(
	this VisualStyleRenderer rnd,
	Color clr,
	int[] states = null
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function GetBackgroundBitmap ( 
	rnd As VisualStyleRenderer,
	clr As Color,
	Optional states As Integer() = Nothing
) As Bitmap
```

<br />

#### Parameters
&nbsp;<dl><dt>rnd</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s6tzc66d" target="_blank">System.Windows.Forms.VisualStyles.VisualStyleRenderer</a><br />The <a href="http://msdn2.microsoft.com/en-us/library/s6tzc66d" target="_blank">VisualStyleRenderer</a> instance.</dd><dt>clr</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/14w97wkc" target="_blank">System.Drawing.Color</a><br />The background color. This color cannot have an alpha channel.</dd><dt>states (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a>[]<br />The optional list of states to render side by side.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/4e7y164x" target="_blank">Bitmap</a><br />The background image.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/s6tzc66d" target="_blank">VisualStyleRenderer</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="5e4a9e29-0aad-8001-c167-4f6bc1cbad58">VisualStylesRendererExtension Class</a><br /><a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions Namespace</a><br />