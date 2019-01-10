using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Windows.Forms
{
	/// <summary>A wrapper around the UxTheme methods.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class VisualTheme : IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="VisualTheme"/> class.</summary>
		/// <param name="classList">A semicolon-separated list of class names to match.</param>
		/// <param name="opt">Optional flags that control how to return the theme data.</param>
		public VisualTheme(string classList, OpenThemeDataOptions opt = OpenThemeDataOptions.None) : this(null, classList, opt) { }

		/// <summary>Initializes a new instance of the <see cref="VisualTheme"/> class.</summary>
		/// <param name="handle">A handle to a theme (HTHEME). This handle will not be freed on disposal.</param>
		public VisualTheme(IntPtr handle)
		{
			Handle = new SafeHTHEME(handle, false);
		}

		/// <summary>Initializes a new instance of the <see cref="VisualTheme"/> class.</summary>
		/// <param name="window">A window or control that the theme is to be retrieved from. This value can be <c>null</c>.</param>
		/// <param name="classList">A semicolon-separated list of class names to match.</param>
		/// <param name="opt">Optional flags that control how to return the theme data.</param>
		/// <exception cref="Win32Exception"></exception>
		public VisualTheme(IWin32Window window, string classList, OpenThemeDataOptions opt = OpenThemeDataOptions.None)
		{
			Handle = OpenThemeDataEx(window?.Handle ?? HWND.NULL, classList, opt);
			if (Handle.IsInvalid)
				throw new Win32Exception();
		}

		/// <summary>Properties accessible via <see cref="GetBitmap"/>.</summary>
		public enum BitmapProperty
		{
			/// <summary>The background image</summary>
			BackgroundImage = ThemeProperty.TMT_DIBDATA,
			/// <summary>The glyph image drawn on top of the background, if present.</summary>
			GlyphImage = ThemeProperty.TMT_GLYPHDIBDATA,
			/// <summary>Not currently supported.</summary>
			Handle = ThemeProperty.TMT_HBITMAP,
		}

		/// <summary>Properties accessible via <see cref="GetBool"/>.</summary>
		public enum BoolProperty
		{
			/// <summary>TRUE if the sizing bar associated with the part and state should always be shown.</summary>
			AlwaysShowSizingBar = ThemeProperty.TMT_ALWAYSSHOWSIZINGBAR,
			/// <summary>TRUE if the nonclient caption area associated with the part and state vary with text width.</summary>
			AutoSize = ThemeProperty.TMT_AUTOSIZE,
			/// <summary>TRUE if true-sized images associated with the part and state are to be drawn on the background fill.</summary>
			BackgroundFill = ThemeProperty.TMT_BGFILL,
			/// <summary>TRUE if the image associated with the part and state should only have its border drawn.</summary>
			BorderOnly = ThemeProperty.TMT_BORDERONLY,
			/// <summary>TRUE if the control associated with the part and state will handle its own compositing of images.</summary>
			Composited = ThemeProperty.TMT_COMPOSITED,
			/// <summary>TMT_COMPOSITEDOPAQUE</summary>
			CompositedOpaque = ThemeProperty.TMT_COMPOSITEDOPAQUE,
			/// <summary>TMT_DRAWBORDERS</summary>
			DrawBorders = ThemeProperty.TMT_DRAWBORDERS,
			/// <summary>Describes how menus are drawn. If <c>true</c>, menus are drawn without shadows. If <c>false</c>, menus have shadows underneath them.</summary>
			FlatMenus = ThemeProperty.TMT_FLATMENUS,
			/// <summary>TRUE if the glyph associated with the part and state should be drawn without a background.</summary>
			GlyphOnly = ThemeProperty.TMT_GLYPHONLY,
			/// <summary>
			/// TRUE if the glyph associated with the part and state have transparent areas. See GetThemeColor for the definition of the TMT_GLYPHCOLOR value
			/// that defines the transparent color.
			/// </summary>
			GlyphTransparent = ThemeProperty.TMT_GLYPHTRANSPARENT,
			/// <summary>TRUE if the truesize image or border associated with the part and state must be sized to a factor of 2.</summary>
			IntegralSizing = ThemeProperty.TMT_INTEGRALSIZING,
			/// <summary>TMT_LOCALIZEDMIRRORIMAGE</summary>
			LocalizedMirrorImage = ThemeProperty.TMT_LOCALIZEDMIRRORIMAGE,
			/// <summary>TRUE if the image associated with the part and state should be flipped if the window is being viewed in right-to-left reading mode.</summary>
			MirrorImage = ThemeProperty.TMT_MIRRORIMAGE,
			/// <summary>TMT_NOETCHEDEFFECT</summary>
			NoEtchedEffect = ThemeProperty.TMT_NOETCHEDEFFECT,
			/// <summary>TMT_SCALEDBACKGROUND</summary>
			ScaledBackground = ThemeProperty.TMT_SCALEDBACKGROUND,
			/// <summary>TRUE if the image associated with the part and state will scale larger in size if necessary.</summary>
			SourceGrow = ThemeProperty.TMT_SOURCEGROW,
			/// <summary>TRUE if the image associated with the part and state will scale smaller in size if necessary.</summary>
			SourceShrink = ThemeProperty.TMT_SOURCESHRINK,
			/// <summary>TMT_TEXTAPPLYOVERLAY</summary>
			TextApplyOverlay = ThemeProperty.TMT_TEXTAPPLYOVERLAY,
			/// <summary></summary>
			TextGlow = ThemeProperty.TMT_TEXTGLOW,
			/// <summary></summary>
			TextItalic = ThemeProperty.TMT_TEXTITALIC,
			/// <summary></summary>
			Transparent = ThemeProperty.TMT_TRANSPARENT,
			/// <summary>TRUE if the image associated with the part and state must have equal height and width.</summary>
			UniformSizing = ThemeProperty.TMT_UNIFORMSIZING,
			/// <summary>TRUE if the image associated with the part and state is based on the current user.</summary>
			UserPicture = ThemeProperty.TMT_USERPICTURE,
		}

		/// <summary>Properties accessible via <see cref="GetColor"/>.</summary>
		public enum ColorProperty
		{
			/// <summary>The color used as an accent color hint for custom controls.</summary>
			AccentColorHint = ThemeProperty.TMT_ACCENTCOLORHINT,
			/// <summary>TMT_ACTIVEBORDER</summary>
			ActiveBorder = ThemeProperty.TMT_ACTIVEBORDER,
			/// <summary>TMT_ACTIVECAPTION</summary>
			ActiveCaption = ThemeProperty.TMT_ACTIVECAPTION,
			/// <summary>TMT_APPWORKSPACE</summary>
			AppWorkspace = ThemeProperty.TMT_APPWORKSPACE,
			/// <summary>TMT_BACKGROUND</summary>
			Background = ThemeProperty.TMT_BACKGROUND,
			/// <summary>The color used as a blend color.</summary>
			BlendColor = ThemeProperty.TMT_BLENDCOLOR,
			/// <summary>TMT_BODYTEXTCOLOR</summary>
			BodyTextColor = ThemeProperty.TMT_BODYTEXTCOLOR,
			/// <summary>The color of the border associated with the part and state.</summary>
			BorderColor = ThemeProperty.TMT_BORDERCOLOR,
			/// <summary>The color used as a border color hint for custom controls.</summary>
			BorderColorHint = ThemeProperty.TMT_BORDERCOLORHINT,
			/// <summary>TMT_BTNFACE</summary>
			ButtonFace = ThemeProperty.TMT_BTNFACE,
			/// <summary>TMT_BTNHIGHLIGHT</summary>
			ButtonHighlight = ThemeProperty.TMT_BTNHIGHLIGHT,
			/// <summary>TMT_BTNSHADOW</summary>
			ButtonShadow = ThemeProperty.TMT_BTNSHADOW,
			/// <summary>TMT_BTNTEXT</summary>
			ButtonText = ThemeProperty.TMT_BTNTEXT,
			/// <summary>TMT_BUTTONALTERNATEFACE</summary>
			ButtonAlternateFace = ThemeProperty.TMT_BUTTONALTERNATEFACE,
			/// <summary>TMT_CAPTIONTEXT</summary>
			CaptionText = ThemeProperty.TMT_CAPTIONTEXT,
			/// <summary>TMT_DKSHADOW3D</summary>
			DarkShadow3D = ThemeProperty.TMT_DKSHADOW3D,
			/// <summary>The dark shadow color of the edge associated with this part and state.</summary>
			EdgeDarkShadowColor = ThemeProperty.TMT_EDGEDKSHADOWCOLOR,
			/// <summary>The fill color of the edge associated with this part and state.</summary>
			EdgeFillColor = ThemeProperty.TMT_EDGEFILLCOLOR,
			/// <summary>The highlight color of the edge associated with this part and state.</summary>
			EdgeHighlightColor = ThemeProperty.TMT_EDGEHIGHLIGHTCOLOR,
			/// <summary>The light color of the edge associated with this part and state.</summary>
			EdgeLightColor = ThemeProperty.TMT_EDGELIGHTCOLOR,
			/// <summary>The shadow color of the edge associated with this part and state.</summary>
			EdgeShadowColor = ThemeProperty.TMT_EDGESHADOWCOLOR,
			/// <summary>The color of the background fill associated with the part and state.</summary>
			FillColor = ThemeProperty.TMT_FILLCOLOR,
			/// <summary>The color used as a fill color hint for custom controls.</summary>
			FillColorHint = ThemeProperty.TMT_FILLCOLORHINT,
			/// <summary>TMT_FROMCOLOR1</summary>
			FromColor1 = ThemeProperty.TMT_FROMCOLOR1,
			/// <summary>TMT_FROMCOLOR2</summary>
			FromColor2 = ThemeProperty.TMT_FROMCOLOR2,
			/// <summary>TMT_FROMCOLOR3</summary>
			FromColor3 = ThemeProperty.TMT_FROMCOLOR3,
			/// <summary>TMT_FROMCOLOR4</summary>
			FromColor4 = ThemeProperty.TMT_FROMCOLOR4,
			/// <summary>TMT_FROMCOLOR5</summary>
			FromColor5 = ThemeProperty.TMT_FROMCOLOR5,
			/// <summary>The color of the glow produced by calling DrawThemeIcon using this part and state.</summary>
			GlowColor = ThemeProperty.TMT_GLOWCOLOR,
			/// <summary>The color that the font-based glyph associated with this part and state will use.</summary>
			GlyphTextColor = ThemeProperty.TMT_GLYPHTEXTCOLOR,
			/// <summary>
			/// The transparent glyph color associated with this part and state. If the TMT_GLYPHTRANSPARENT value for this part and state is TRUE, parts of the
			/// glyph that use this color are not drawn.
			/// </summary>
			GlyphTransparentColor = ThemeProperty.TMT_GLYPHTRANSPARENTCOLOR,
			/// <summary>TMT_GRADIENTACTIVECAPTION</summary>
			GradientActiveCaption = ThemeProperty.TMT_GRADIENTACTIVECAPTION,
			/// <summary>The first color of the gradient associated with this part and state.</summary>
			GradientColor1 = ThemeProperty.TMT_GRADIENTCOLOR1,
			/// <summary>The second color of the gradient.</summary>
			GradientColor2 = ThemeProperty.TMT_GRADIENTCOLOR2,
			/// <summary>The third color of the gradient.</summary>
			GradientColor3 = ThemeProperty.TMT_GRADIENTCOLOR3,
			/// <summary>The fourth color of the gradient.</summary>
			GradientColor4 = ThemeProperty.TMT_GRADIENTCOLOR4,
			/// <summary>The fifth color of the gradient.</summary>
			GradientColor5 = ThemeProperty.TMT_GRADIENTCOLOR5,
			/// <summary>TMT_GRADIENTINACTIVECAPTION</summary>
			GradientInactiveCaption = ThemeProperty.TMT_GRADIENTINACTIVECAPTION,
			/// <summary>TMT_GRAYTEXT</summary>
			GrayText = ThemeProperty.TMT_GRAYTEXT,
			/// <summary>TMT_HEADING1TEXTCOLOR</summary>
			Heading1TextColor = ThemeProperty.TMT_HEADING1TEXTCOLOR,
			/// <summary>TMT_HEADING2TEXTCOLOR</summary>
			Heading2TextColor = ThemeProperty.TMT_HEADING2TEXTCOLOR,
			/// <summary>TMT_HIGHLIGHT</summary>
			Highlight = ThemeProperty.TMT_HIGHLIGHT,
			/// <summary>TMT_HIGHLIGHTTEXT</summary>
			HighlightText = ThemeProperty.TMT_HIGHLIGHTTEXT,
			/// <summary>TMT_HOTTRACKING</summary>
			HotTracking = ThemeProperty.TMT_HOTTRACKING,
			/// <summary>TMT_INACTIVEBORDER</summary>
			InactiveBorder = ThemeProperty.TMT_INACTIVEBORDER,
			/// <summary>TMT_INACTIVECAPTION</summary>
			InactiveCaption = ThemeProperty.TMT_INACTIVECAPTION,
			/// <summary>TMT_INACTIVECAPTIONTEXT</summary>
			InactiveCaptionText = ThemeProperty.TMT_INACTIVECAPTIONTEXT,
			/// <summary>TMT_INFOBK</summary>
			InfoBackground = ThemeProperty.TMT_INFOBK,
			/// <summary>TMT_INFOTEXT</summary>
			InfoText = ThemeProperty.TMT_INFOTEXT,
			/// <summary>TMT_LIGHT3D</summary>
			Light3D = ThemeProperty.TMT_LIGHT3D,
			/// <summary>TMT_MENU</summary>
			Menu = ThemeProperty.TMT_MENU,
			/// <summary>TMT_MENUBAR</summary>
			MenuBar = ThemeProperty.TMT_MENUBAR,
			/// <summary>TMT_MENUHILIGHT</summary>
			MenuHilight = ThemeProperty.TMT_MENUHILIGHT,
			/// <summary>TMT_MENUTEXT</summary>
			MenuText = ThemeProperty.TMT_MENUTEXT,
			/// <summary>TMT_SCROLLBAR</summary>
			ScrollBar = ThemeProperty.TMT_SCROLLBAR,
			/// <summary>The color of the shadow drawn underneath text associated with this part and state.</summary>
			ShadowColor = ThemeProperty.TMT_SHADOWCOLOR,
			/// <summary>The color of the text border associated with this part and state.</summary>
			TextBorderColor = ThemeProperty.TMT_TEXTBORDERCOLOR,
			/// <summary>The color of the text associated with this part and state.</summary>
			TextColor = ThemeProperty.TMT_TEXTCOLOR,
			/// <summary>TMT_TEXTCOLORHINT</summary>
			TextColorHint = ThemeProperty.TMT_TEXTCOLORHINT,
			/// <summary>The color of the text shadow associated with this part and state.</summary>
			TextShadowColor = ThemeProperty.TMT_TEXTSHADOWCOLOR,
			/// <summary>
			/// The transparent color associated with this part and state. If the TMT_TRANSPARENT value for this part and state is TRUE, parts of the graphic
			/// that use this color are not drawn.
			/// </summary>
			TransparentColor = ThemeProperty.TMT_TRANSPARENTCOLOR,
			/// <summary>TMT_WINDOW</summary>
			Window = ThemeProperty.TMT_WINDOW,
			/// <summary>TMT_WINDOWFRAME</summary>
			WindowFrame = ThemeProperty.TMT_WINDOWFRAME,
			/// <summary>TMT_WINDOWTEXT</summary>
			WindowText = ThemeProperty.TMT_WINDOWTEXT,
		}

		/// <summary>Properties accessible via <c>GetEnumValue</c>.</summary>
		public enum EnumProperty
		{
			/// <summary>The basic drawing type for this part.</summary>
			BackgroundType = ThemeProperty.TMT_BGTYPE,
			/// <summary>The type of border drawn if this part is a border fill.</summary>
			BorderType = ThemeProperty.TMT_BORDERTYPE,
			/// <summary>The alignment of text in the caption associated with this part.</summary>
			ContentAlignment = ThemeProperty.TMT_CONTENTALIGNMENT,
			/// <summary>The type of fill shape drawn if this part is a border fill.</summary>
			FillType = ThemeProperty.TMT_FILLTYPE,
			/// <summary>The type of glyph drawn on this part.</summary>
			GlyphType = ThemeProperty.TMT_GLYPHTYPE,
			/// <summary>The type of method used to select between different-sized glyphs.</summary>
			GlyphFontSizingType = ThemeProperty.TMT_GLYPHFONTSIZINGTYPE,
			/// <summary>The horizontal alignment if this part uses a true-size image.</summary>
			HAlign = ThemeProperty.TMT_HALIGN,
			/// <summary>The type of effect to be displayed when this part is drawn using DrawThemeIcon.</summary>
			IconEffect = ThemeProperty.TMT_ICONEFFECT,
			/// <summary>The type of alignment used when multiple images are drawn.</summary>
			ImageLayout = ThemeProperty.TMT_IMAGELAYOUT,
			/// <summary>The type of method used to select between sized images for this part. See the TMT_IMAGEFILE1 value of GetThemeFilename.</summary>
			ImageSelectType = ThemeProperty.TMT_IMAGESELECTTYPE,
			/// <summary>The alignment of this part on the window.</summary>
			OffsetType = ThemeProperty.TMT_OFFSETTYPE,
			/// <summary>The method used to size an image if this part uses an image file.</summary>
			SizingType = ThemeProperty.TMT_SIZINGTYPE,
			/// <summary>The type of shadow effect to draw behind text associated with this part.</summary>
			TextShadowType = ThemeProperty.TMT_TEXTSHADOWTYPE,
			/// <summary>The type of scaling used if this part uses a true-sized image.</summary>
			TrueSizeScalingType = ThemeProperty.TMT_TRUESIZESCALINGTYPE,
			/// <summary>The vertical alignment if this part uses a true-size image.</summary>
			VAlign = ThemeProperty.TMT_VALIGN,
		}

		/// <summary>Properties accessible via <see cref="GetFilename"/>.</summary>
		public enum FilenameProperty
		{
			/// <summary>The filename for the glyph image associated with this part and state.</summary>
			GlyphImageFile = ThemeProperty.TMT_GLYPHIMAGEFILE,
			/// <summary>
			/// The filename of the image associated with this part and state, or the base filename for multiple images associated with this part and state.
			/// </summary>
			ImageFile = ThemeProperty.TMT_IMAGEFILE,
			/// <summary>The filename of the first scaled image associated with this part and state, for support of different resolutions.</summary>
			ImageFile1 = ThemeProperty.TMT_IMAGEFILE1,
			/// <summary>The filename of the second scaled image.</summary>
			ImageFile2 = ThemeProperty.TMT_IMAGEFILE2,
			/// <summary>The filename of the third scaled image.</summary>
			ImageFile3 = ThemeProperty.TMT_IMAGEFILE3,
			/// <summary>The filename of the fourth scaled image.</summary>
			ImageFile4 = ThemeProperty.TMT_IMAGEFILE4,
			/// <summary>The filename of the fifth scaled image.</summary>
			ImageFile5 = ThemeProperty.TMT_IMAGEFILE5,
		}

		/// <summary>Properties accessible via <see cref="GetFont"/>.</summary>
		public enum FontProperty
		{
			/// <summary>TMT_BODYFONT</summary>
			Body = ThemeProperty.TMT_BODYFONT,
			/// <summary>The font that the glyph associated with this part will be drawn with, if font-based glyphs are used.</summary>
			Glyph = ThemeProperty.TMT_GLYPHFONT,
			/// <summary>TMT_HEADING1FONT</summary>
			Heading1 = ThemeProperty.TMT_HEADING1FONT,
			/// <summary>TMT_HEADING2FONT</summary>
			Heading2 = ThemeProperty.TMT_HEADING2FONT,

			/// <summary></summary>
			Caption = ThemeProperty.TMT_CAPTIONFONT,
			/// <summary>TMT_ICONTITLEFONT</summary>
			IconTitle = ThemeProperty.TMT_ICONTITLEFONT,
			/// <summary>TMT_MENUFONT</summary>
			Menu = ThemeProperty.TMT_MENUFONT,
			/// <summary>TMT_MSGBOXFONT</summary>
			MessageBox = ThemeProperty.TMT_MSGBOXFONT,
			/// <summary>TMT_SMALLCAPTIONFONT</summary>
			SmallCaption = ThemeProperty.TMT_SMALLCAPTIONFONT,
			/// <summary>TMT_STATUSFONT</summary>
			Status = ThemeProperty.TMT_STATUSFONT,
		}

		/// <summary>Properties accessible via <see cref="GetInt"/>.</summary>
		public enum IntProperty
		{
			/// <summary>TMT_ANIMATIONDELAY</summary>
			AnimationDelay = ThemeProperty.TMT_ANIMATIONDELAY,
			/// <summary>TMT_ANIMATIONDURATION</summary>
			AnimationDuration = ThemeProperty.TMT_ANIMATIONDURATION,
			/// <summary>TMT_CHARSET</summary>
			CharSet = ThemeProperty.TMT_CHARSET,
			/// <summary>TMT_COLORIZATIONCOLOR</summary>
			ColorizationColor = ThemeProperty.TMT_COLORIZATIONCOLOR,
			/// <summary>TMT_COLORIZATIONOPACITY</summary>
			ColorizationOpacity = ThemeProperty.TMT_COLORIZATIONOPACITY,
			/// <summary>TMT_FRAMESPERSECOND</summary>
			FramesPerSecond = ThemeProperty.TMT_FRAMESPERSECOND,
			/// <summary>TMT_FROMHUE1</summary>
			FromHue1 = ThemeProperty.TMT_FROMHUE1,
			/// <summary>TMT_FROMHUE2</summary>
			FromHue2 = ThemeProperty.TMT_FROMHUE2,
			/// <summary>TMT_FROMHUE3</summary>
			FromHue3 = ThemeProperty.TMT_FROMHUE3,
			/// <summary>TMT_FROMHUE4</summary>
			FromHue4 = ThemeProperty.TMT_FROMHUE4,
			/// <summary>TMT_FROMHUE5</summary>
			FromHue5 = ThemeProperty.TMT_FROMHUE5,
			/// <summary>TMT_GLOWINTENSITY</summary>
			GlowIntensity = ThemeProperty.TMT_GLOWINTENSITY,
			/// <summary>Gets the minimum color depth, in bits, required to properly view this style.</summary>
			MinimumColorDepth = ThemeProperty.TMT_MINCOLORDEPTH,
			/// <summary>TMT_OPACITY</summary>
			Opacity = ThemeProperty.TMT_OPACITY,
			/// <summary>TMT_PIXELSPERFRAME</summary>
			PixelsPerFrame = ThemeProperty.TMT_PIXELSPERFRAME,
			/// <summary>TMT_TEXTGLOWSIZE</summary>
			TextGlowSize = ThemeProperty.TMT_TEXTGLOWSIZE,
			/// <summary>TMT_TOCOLOR1</summary>
			ToColor1 = ThemeProperty.TMT_TOCOLOR1,
			/// <summary>TMT_TOCOLOR2</summary>
			ToColor2 = ThemeProperty.TMT_TOCOLOR2,
			/// <summary>TMT_TOCOLOR3</summary>
			ToColor3 = ThemeProperty.TMT_TOCOLOR3,
			/// <summary>TMT_TOCOLOR4</summary>
			ToColor4 = ThemeProperty.TMT_TOCOLOR4,
			/// <summary>TMT_TOCOLOR5</summary>
			ToColor5 = ThemeProperty.TMT_TOCOLOR5,
			/// <summary>TMT_TOHUE1</summary>
			ToHue1 = ThemeProperty.TMT_TOHUE1,
			/// <summary>TMT_TOHUE2</summary>
			ToHue2 = ThemeProperty.TMT_TOHUE2,
			/// <summary>TMT_TOHUE3</summary>
			ToHue3 = ThemeProperty.TMT_TOHUE3,
			/// <summary>TMT_TOHUE4</summary>
			ToHue4 = ThemeProperty.TMT_TOHUE4,
			/// <summary>TMT_TOHUE5</summary>
			ToHue5 = ThemeProperty.TMT_TOHUE5,
		}

		/// <summary>Properties accessible via <see cref="GetMargins"/>.</summary>
		public enum MarginsProperty
		{
			/// <summary>The margins that define where caption text may be placed within a part.</summary>
			Caption = ThemeProperty.TMT_CAPTIONMARGINS,
			/// <summary>The margins that define where content may be placed within a part.</summary>
			Content = ThemeProperty.TMT_CONTENTMARGINS,
			/// <summary>The margins used for sizing a non-true-size image.</summary>
			Sizing = ThemeProperty.TMT_SIZINGMARGINS,
		}

		/// <summary>Properties accessible via <see cref="GetMetric"/>.</summary>
		public enum MetricProperty
		{
			/// <summary>The alpha value (0-255) used for DrawThemeIcon.</summary>
			AlphaLevel = ThemeProperty.TMT_ALPHALEVEL,
			/// <summary>The minimum alpha value (0-255) that a pixel must have to be considered opaque.</summary>
			AlphaThreshold = ThemeProperty.TMT_ALPHATHRESHOLD,
			/// <summary>The thickness of the border drawn if this part uses a border fill.</summary>
			BorderSize = ThemeProperty.TMT_BORDERSIZE,
			/// <summary>The character index into the selected font that will be used for the glyph, if the part uses a font-based glyph.</summary>
			GlyphIndex = ThemeProperty.TMT_GLYPHINDEX,
			/// <summary>
			/// The amount of the first gradient color (TMT_GRADIENTCOLOR1) to use in drawing the part. This value can be from 0 to 255, but this value plus the
			/// values of each of the GRADIENTRATIO values must add up to 255.
			/// </summary>
			GradientRatio1 = ThemeProperty.TMT_GRADIENTRATIO1,
			/// <summary>The amount of the second gradient color (TMT_GRADIENTCOLOR2) to use in drawing the part.</summary>
			GradientRatio2 = ThemeProperty.TMT_GRADIENTRATIO2,
			/// <summary>The amount of the third gradient color (TMT_GRADIENTCOLOR3) to use in drawing the part.</summary>
			GradientRatio3 = ThemeProperty.TMT_GRADIENTRATIO3,
			/// <summary>The amount of the fourth gradient color (TMT_GRADIENTCOLOR4) to use in drawing the part.</summary>
			GradientRatio4 = ThemeProperty.TMT_GRADIENTRATIO4,
			/// <summary>The amount of the fifth gradient color (TMT_GRADIENTCOLOR5) to use in drawing the part.</summary>
			GradientRatio5 = ThemeProperty.TMT_GRADIENTRATIO5,
			/// <summary>The height of the part.</summary>
			Height = ThemeProperty.TMT_HEIGHT,
			/// <summary>The number of state images present in an image file.</summary>
			ImageCount = ThemeProperty.TMT_IMAGECOUNT,
			/// <summary>The minimum dots per inch (dpi) that the first image file was designed for.</summary>
			MinDpi1 = ThemeProperty.TMT_MINDPI1,
			/// <summary>The minimum dpi that the second image file was designed for.</summary>
			MinDpi2 = ThemeProperty.TMT_MINDPI2,
			/// <summary>The minimum dpi that the third image file was designed for.</summary>
			MinDpi3 = ThemeProperty.TMT_MINDPI3,
			/// <summary>The minimum dpi that the fourth image file was designed for.</summary>
			MinDpi4 = ThemeProperty.TMT_MINDPI4,
			/// <summary>The minimum dpi that the fifth image file was designed for.</summary>
			MinDpi5 = ThemeProperty.TMT_MINDPI5,
			/// <summary>The size of the progress control "chunk" shapes that define how far an operation has progressed.</summary>
			ProgressChunkSize = ThemeProperty.TMT_PROGRESSCHUNKSIZE,
			/// <summary>The total size of all of the progress control "chunks".</summary>
			ProgressSpaceSize = ThemeProperty.TMT_PROGRESSSPACESIZE,
			/// <summary>The roundness (0 to 100 percent) of the part's corners.</summary>
			RoundCornerHeight = ThemeProperty.TMT_ROUNDCORNERHEIGHT,
			/// <summary>The roundness (0 to 100 percent) of the part's corners.</summary>
			RoundCornerWidth = ThemeProperty.TMT_ROUNDCORNERWIDTH,
			/// <summary>The amount of saturation (0-255) to apply to an icon drawn using DrawThemeIcon.</summary>
			Saturation = ThemeProperty.TMT_SATURATION,
			/// <summary>The thickness of the border drawn around text characters.</summary>
			TextBorderSize = ThemeProperty.TMT_TEXTBORDERSIZE,
			/// <summary>The percentage of a true-size image's original size at which the image will be stretched.</summary>
			TrueSizeStretchMark = ThemeProperty.TMT_TRUESIZESTRETCHMARK,
			/// <summary>The width of the part.</summary>
			Width = ThemeProperty.TMT_WIDTH,
		}

		/// <summary>Identifies the type of size value to retrieve for a visual style part.</summary>
		public enum PartSize
		{
			/// <summary>Receives the minimum size of a visual style part.</summary>
			Minimum = THEMESIZE.TS_MIN,
			/// <summary>Receives the size of the visual style part that will best fit the available space.</summary>
			BestFit = THEMESIZE.TS_TRUE,
			/// <summary>Receives the size that the theme manager uses to draw a part.</summary>
			Default = THEMESIZE.TS_DRAW
		}

		/// <summary>Properties accessible via <see cref="GetPosition"/>.</summary>
		public enum PositionProperty
		{
			/// <summary>The minimum size that the normal image file can be used for before moving to the next smallest image file.</summary>
			MinSize = ThemeProperty.TMT_MINSIZE,
			/// <summary>The minimum size that the first small image file can be used for.</summary>
			MinSize1 = ThemeProperty.TMT_MINSIZE1,
			/// <summary>The minimum size that the second small image file can be used for.</summary>
			MinSize2 = ThemeProperty.TMT_MINSIZE2,
			/// <summary>The minimum size that the third small image file can be used for.</summary>
			MinSize3 = ThemeProperty.TMT_MINSIZE3,
			/// <summary>The minimum size that the fourth small image file can be used for.</summary>
			MinSize4 = ThemeProperty.TMT_MINSIZE4,
			/// <summary>The minimum size that the fifth small image file can be used for.</summary>
			MinSize5 = ThemeProperty.TMT_MINSIZE5,
			/// <summary>The size of the normal image associated with this part.</summary>
			NormalSize = ThemeProperty.TMT_NORMALSIZE,
			/// <summary>The position offset from the alignment for this part. The alignment is defined by the TMT_OFFSETTYPE value.</summary>
			Offset = ThemeProperty.TMT_OFFSET,
			/// <summary>The offset from the text at which text shadows are drawn.</summary>
			TextShadowOffset = ThemeProperty.TMT_TEXTSHADOWOFFSET,
		}

		/// <summary>Returned by <c>GetPropertyOrigin</c> to specify where a property was found.</summary>
		public enum PropertyOrigin
		{
			/// <summary>Property was found in the state section.</summary>
			State = PROPERTYORIGIN.PO_STATE,
			/// <summary>Property was found in the part section.</summary>
			Part = PROPERTYORIGIN.PO_PART,
			/// <summary>Property was found in the class section.</summary>
			Class = PROPERTYORIGIN.PO_CLASS,
			/// <summary>Property was found in the list of global variables.</summary>
			Global = PROPERTYORIGIN.PO_GLOBAL,
			/// <summary>Property was not found.</summary>
			NotFound = PROPERTYORIGIN.PO_NOTFOUND
		}

		/// <summary>Properties accessible via <see cref="GetRect"/>.</summary>
		public enum RectangleProperty
		{
			/// <summary>TMT_ANIMATIONBUTTONRECT</summary>
			AnimationButton = ThemeProperty.TMT_ANIMATIONBUTTONRECT,
			/// <summary>TMT_ATLASRECT</summary>
			Atlas = ThemeProperty.TMT_ATLASRECT,
			/// <summary>TMT_CUSTOMSPLITRECT</summary>
			CustomSplit = ThemeProperty.TMT_CUSTOMSPLITRECT,
			/// <summary>The default size of the part.</summary>
			DefaultPane = ThemeProperty.TMT_DEFAULTPANESIZE,
		}

		/// <summary>Properties accessible via <see cref="GetString"/>.</summary>
		public enum StringProperty
		{
			/// <summary>TMT_ALIAS</summary>
			Alias = ThemeProperty.TMT_ALIAS,
			/// <summary>TMT_ATLASINPUTIMAGE</summary>
			AtlasInputImage = ThemeProperty.TMT_ATLASINPUTIMAGE,
			/// <summary>TMT_AUTHOR</summary>
			Author = ThemeProperty.TMT_AUTHOR,
			/// <summary>TMT_CLASSICVALUE</summary>
			ClassicValue = ThemeProperty.TMT_CLASSICVALUE,
			/// <summary>TMT_COLORSCHEMES</summary>
			ColorSchemes = ThemeProperty.TMT_COLORSCHEMES,
			/// <summary>TMT_COMPANY</summary>
			Company = ThemeProperty.TMT_COMPANY,
			/// <summary>TMT_COPYRIGHT</summary>
			Copyright = ThemeProperty.TMT_COPYRIGHT,
			/// <summary>See GetThemeSysString.</summary>
			CssName = ThemeProperty.TMT_CSSNAME,
			/// <summary>TMT_DESCRIPTION</summary>
			Description = ThemeProperty.TMT_DESCRIPTION,
			/// <summary>TMT_DISPLAYNAME</summary>
			DisplayName = ThemeProperty.TMT_DISPLAYNAME,
			/// <summary>TMT_LASTUPDATED</summary>
			LastUpdated = ThemeProperty.TMT_LASTUPDATED,
			/// <summary>TMT_SIZES</summary>
			Sizes = ThemeProperty.TMT_SIZES,
			/// <summary>The text displayed by the part.</summary>
			Text = ThemeProperty.TMT_TEXT,
			/// <summary>TMT_TOOLTIP</summary>
			Tooltip = ThemeProperty.TMT_TOOLTIP,
			/// <summary>TMT_URL</summary>
			Url = ThemeProperty.TMT_URL,
			/// <summary>TMT_VERSION</summary>
			Version = ThemeProperty.TMT_VERSION,
			/// <summary>See GetThemeSysString.</summary>
			XmlName = ThemeProperty.TMT_XMLNAME,
			/// <summary>TMT_NAME</summary>
			Name = ThemeProperty.TMT_NAME,
		}

		private enum PropertyType
		{
			Unknown = 0,
			Enum = 200,
			String = 201,
			Int = 202,
			SysInt = 198,
			Metric = 199,
			Bool = 203,
			Color = 204,
			Margins = 205,
			FileName = 206,
			Size = 207,
			Position = 208,
			Rect = 209,
			Font = 210,
			IntList = 211,
			HBitmap = 212,
			DiskStream = 213,
			Stream = 214
		}

		/// <summary>Gets the full path of the current visual style file.</summary>
		public static string CurrentThemePath
		{
			get
			{
				var sb = new StringBuilder(MAX_PATH);
				return GetCurrentThemeName(sb, MAX_PATH, null, 0, null, 0).Succeeded ? sb.ToString() : null;
			}
		}

		/// <summary>Gets the name of the author of the theme.</summary>
		public string Author => GetDocumentationProperty(CurrentThemePath, SZ_THDOCPROP_AUTHOR);

		/// <summary>Gets the name of the theme.</summary>
		public string CanonicalName => GetDocumentationProperty(CurrentThemePath, SZ_THDOCPROP_CANONICALNAME);

		/// <summary>Gets the display name of the theme.</summary>
		public string DisplayName => GetDocumentationProperty(CurrentThemePath, SZ_THDOCPROP_DISPLAYNAME);

		/// <summary>Gets the native theme handle (HTHEME).</summary>
		public SafeHTHEME Handle { get; private set; }

		/// <summary>Gets the tooltip associated with this theme.</summary>
		public string Tooltip => GetDocumentationProperty(CurrentThemePath, SZ_THDOCPROP_TOOLTIP);

		/// <summary>Retrieves the value for a theme property from the documentation section of the specified theme file.</summary>
		/// <param name="themeFile">The name of the theme file that will be opened to query for the property.</param>
		/// <param name="prop">The name of the theme property to query.</param>
		/// <returns>The property string value.</returns>
		public static string GetDocumentationProperty(string themeFile, string prop)
		{
			var sb = new StringBuilder(MAX_PATH);
			return GetThemeDocumentationProperty(themeFile, prop, sb, MAX_PATH).Succeeded ? sb.ToString() : null;
		}

		/// <summary>Uses the aero wizard background style for a window or control.</summary>
		/// <param name="window">The window or control.</param>
		/// <param name="enable">If set to <see langword="true"/> apply the background style; <see langword="false"/> to remove.</param>
		public static void UseAeroWizardTexture(IWin32Window window, bool enable) =>
					EnableThemeDialogTexture(window.Handle, ThemeDialogTextureFlags.ETDT_USEAEROWIZARDTABTEXTURE | (enable ? ThemeDialogTextureFlags.ETDT_ENABLE : ThemeDialogTextureFlags.ETDT_DISABLE));

		/// <summary>Uses the tab control background style for a window or control.</summary>
		/// <param name="window">The window or control.</param>
		/// <param name="enable">If set to <see langword="true"/> apply the background style; <see langword="false"/> to remove.</param>
		public static void UseTabTexture(IWin32Window window, bool enable) =>
					EnableThemeDialogTexture(window.Handle, ThemeDialogTextureFlags.ETDT_USETABTEXTURE | (enable ? ThemeDialogTextureFlags.ETDT_ENABLE : ThemeDialogTextureFlags.ETDT_DISABLE));

		/// <summary>Retrieves a hit test code for a point in the background specified by a visual style.</summary>
		/// <param name="dc">Device context.</param>
		/// <param name="partId">Value that specifies the part.</param>
		/// <param name="stateId">Value that specifies the state of the part.</param>
		/// <param name="bounds">The rectangle, in logical coordinates, that bounds the background.</param>
		/// <param name="pt">The coordinates of the point.</param>
		/// <param name="options">The hit test options.</param>
		/// <returns>The hit test code that indicates whether the point in <paramref name="pt"/> is in the background area bounded by <paramref name="bounds"/>.</returns>
		public System.Windows.Forms.VisualStyles.HitTestCode BackgroundHitTest(IDeviceContext dc, int partId, int stateId, Rectangle bounds, Point pt, System.Windows.Forms.VisualStyles.HitTestOptions options = 0)
		{
			using (var hdc = new SafeHDC(dc))
				return HitTestThemeBackground(Handle, hdc, partId, stateId, (HitTestOptions)options, bounds, HRGN.NULL, pt, out var htcode).Succeeded ? (System.Windows.Forms.VisualStyles.HitTestCode)htcode : 0;
		}

		/// <summary>Retrieves a hit test code for a point in the background specified by a visual style.</summary>
		/// <param name="graphics">Device context.</param>
		/// <param name="partId">Value that specifies the part.</param>
		/// <param name="stateId">Value that specifies the state of the part.</param>
		/// <param name="bounds">The rectangle, in logical coordinates, that bounds the background.</param>
		/// <param name="region">A region used to specify the bounds of a hit test area.</param>
		/// <param name="pt">The coordinates of the point.</param>
		/// <param name="options">The hit test options.</param>
		/// <returns>
		/// The hit test code that indicates whether the point in <paramref name="pt"/> is in the background area bounded by <paramref name="bounds"/> or <paramref name="region"/>.
		/// </returns>
		public System.Windows.Forms.VisualStyles.HitTestCode BackgroundHitTest(Graphics graphics, int partId, int stateId, Rectangle bounds, Region region, Point pt, System.Windows.Forms.VisualStyles.HitTestOptions options = 0)
		{
			using (var hdc = new SafeHDC(graphics))
				return HitTestThemeBackground(Handle, hdc, partId, stateId, (HitTestOptions)options, bounds, new HRGN(region.GetHrgn(graphics)), pt, out var htcode).Succeeded ? (System.Windows.Forms.VisualStyles.HitTestCode)htcode : 0;
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose() { Handle?.Dispose(); }

		/// <summary>Draws the background image defined by the visual style for the specified control part.</summary>
		/// <param name="graphics">Used for drawing the theme-defined background image.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="bounds">The bounds, in logical coordinates, in which the background image is drawn.</param>
		/// <param name="clipRect">An optional rectangle that specifies the bounding rectangle of the clip region.</param>
		/// <param name="rightToLeft">if set to <c>true</c> mirror the device context for right to left drawing.</param>
		/// <param name="omitBorder">if set to <c>true</c> omit border when drawing.</param>
		/// <param name="omitContent">if set to <c>true</c> omit content when drawing.</param>
		public void DrawBackground(IDeviceContext graphics, int partId, int stateId, Rectangle bounds, Rectangle? clipRect, bool rightToLeft = false, bool omitBorder = false, bool omitContent = false)
		{
			var o = new DTBGOPTS(clipRect) {HasMirroredDC = rightToLeft, OmitBorder = omitBorder, OmitContent = omitContent};
			using (var hdc = new SafeHDC(graphics))
				DrawThemeBackgroundEx(Handle, hdc, partId, stateId, bounds, o);
		}

		/// <summary>Draws one or more edges defined by the visual style of a rectangle.</summary>
		/// <param name="graphics">Used for drawing the theme-defined edge.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="bounds">The bounding rectangle, in logical coordinates.</param>
		/// <param name="edges">Specifies the type of inner and outer edges to draw.</param>
		/// <param name="borderType">
		/// Specifies the type of border to draw. If BF_ADJUST is specified, <paramref name="bounds"/> will be shrunk to exclude the edges that were drawn upon return.
		/// </param>
		public void DrawEdge(IDeviceContext graphics, int partId, int stateId, ref Rectangle bounds, BorderStyles3D edges = BorderStyles3D.BDR_SUNKEN, BorderFlags borderType = BorderFlags.BF_RECT | BorderFlags.BF_ADJUST)
		{
			using (var hdc = new SafeHDC(graphics))
			{
				DrawThemeEdge(Handle, hdc, partId, stateId, bounds, edges, borderType, out var r);
				if (borderType.IsFlagSet(BorderFlags.BF_ADJUST))
					bounds = r;
			}
		}

		/// <summary>Draws an image from an image list with the icon effect defined by the visual style.</summary>
		/// <param name="graphics">Used for drawing the icon.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="imageList">An <c>image list</c> that contains the image to draw.</param>
		/// <param name="imageIndex">Value that specifies the index of the image to draw.</param>
		/// <param name="bounds">The bounding rectangle, in logical coordinates.</param>
		public void DrawIcon(IDeviceContext graphics, int partId, int stateId, ImageList imageList, int imageIndex, Rectangle bounds)
		{
			using (var hdc = new SafeHDC(graphics))
				DrawThemeIcon(Handle, hdc, partId, stateId, bounds, imageList.Handle, imageIndex);
		}

		/// <summary>Draws the part of a parent control that is covered by a partially-transparent or alpha-blended child control.</summary>
		/// <param name="childWindow">The child control.</param>
		/// <param name="graphics">The child control's device context.</param>
		/// <param name="bounds">
		/// The area to be drawn. The rectangle is in the child window's coordinates. If this parameter is NULL, the area to be drawn includes the entire area
		/// occupied by the child control.
		/// </param>
		public void DrawParentBackground(IWin32Window childWindow, IDeviceContext graphics, Rectangle? bounds = null)
		{
			using (var hdc = new SafeHDC(graphics))
				DrawThemeParentBackground(childWindow.Handle, hdc, bounds);
		}

		/// <summary>Draws text using the color and font defined by the visual style.</summary>
		/// <param name="graphics">Used for drawing the text.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="bounds">The bounding rectangle, in logical coordinates.</param>
		/// <param name="text">A string that contains the text to draw.</param>
		/// <param name="fmt">One or more values that specify the string's formatting.</param>
		/// <param name="disabled">Draw text disabled.</param>
		/// <param name="font">The font to use when drawing the text. If <c>null</c>, the default system font is used.</param>
		public void DrawText(IDeviceContext graphics, int partId, int stateId, Rectangle bounds, string text, TextFormatFlags fmt = TextFormatFlags.Default, bool disabled = false, Font font = null)
		{
			RECT b = bounds;
			using (var hdc = new SafeHDC(graphics))
			using (var hfont = new SafeHFONT(font?.ToHfont() ?? IntPtr.Zero))
			using (hdc.SelectObject(hfont))
				DrawThemeText(Handle, hdc, partId, stateId, text, text.Length, (DrawTextFlags)fmt, disabled ? 1 : 0, b);
		}

		/// <summary>Draws text using the color and font defined by the visual style.</summary>
		/// <param name="graphics">Used for drawing the text.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="bounds">The bounding rectangle, in logical coordinates.</param>
		/// <param name="text">A string that contains the text to draw.</param>
		/// <param name="fmt">One or more values that specify the string's formatting.</param>
		/// <param name="options">Additional formatting options.</param>
		/// <param name="font">The font to use when drawing the text. If <c>null</c>, the default system font is used.</param>
		public void DrawText(IDeviceContext graphics, int partId, int stateId, Rectangle bounds, string text, TextFormatFlags fmt = TextFormatFlags.Default, DTTOPTS? options = null, Font font = null)
		{
			RECT b = bounds;
			var dt = options ?? DTTOPTS.Default;
			using (var hdc = new SafeHDC(graphics))
			using (var hfont = new SafeHFONT(font?.ToHfont() ?? IntPtr.Zero))
			using (hdc.SelectObject(hfont))
				DrawThemeTextEx(Handle, hdc, partId, stateId, text, text.Length, (DrawTextFlags)fmt, ref b, dt);
		}

		/// <summary>Retrieves the size of the content area for the background defined by the visual style.</summary>
		/// <param name="graphics">The device context to use when drawing. This parameter may be set to <c>null</c>.</param>
		/// <param name="partId">Value that specifies the part to draw.</param>
		/// <param name="stateId">Value that specifies the state of the part to draw.</param>
		/// <param name="bounds">The total background rectangle, in logical coordinates.</param>
		/// <returns>The content area background rectangle, in logical coordinates. This rectangle is calculated to fit the content area.</returns>
		public Rectangle? GetBackgroundContentRect([Optional] IDeviceContext graphics, int partId, int stateId, Rectangle bounds)
		{
			using (var hdc = new SafeHDC(graphics))
				return GetThemeBackgroundContentRect(Handle, hdc, partId, stateId, bounds, out var rc).Succeeded ? (Rectangle?)rc : null;
		}

		/// <summary>Calculates the size and location of the background, defined by the visual style, given the content area.</summary>
		/// <param name="graphics">The device context to use when drawing. This parameter may be set to <c>null</c>.</param>
		/// <param name="partId">Value that specifies the part that contains the content.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the content.</param>
		/// <param name="bounds">The content background rectangle, in logical coordinates.</param>
		/// <returns>The background rectangle, in logical coordinates. This rectangle is based on <paramref name="bounds"/>.</returns>
		public Rectangle? GetBackgroundExtent([Optional] IDeviceContext graphics, int partId, int stateId, Rectangle bounds)
		{
			using (var hdc = new SafeHDC(graphics))
				return GetThemeBackgroundExtent(Handle, hdc, partId, stateId, bounds, out var rc).Succeeded ? (Rectangle?)rc : null;
		}

		/// <summary>Retrieves the bitmap associated with a particular theme, part, state, and property.</summary>
		/// <param name="partId">Value that specifies the part that contains the bitmap.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the bitmap.</param>
		/// <param name="propId">The bitmap property identifier.</param>
		/// <returns>The requested bitmap, if successful; otherwise <c>null</c>.</returns>
		public Bitmap GetBitmap(int partId, int stateId, BitmapProperty propId) => GetThemeBitmap(Handle, partId, stateId, (int)propId, GBF.GBF_COPY, out var hBmp).Succeeded ? hBmp.ToBitmap() : null;

		/// <summary>Retrieves the value of a <c>bool</c> property from the SysMetrics section of theme data.</summary>
		/// <param name="partId">Value that specifies the part that contains the bool property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the bool property.</param>
		/// <param name="propId">The bool property identifier.</param>
		/// <returns>The requested bool value, if successful; otherwise <c>null</c>.</returns>
		public bool? GetBool(int partId, int stateId, BoolProperty propId)
		{
			if (GetThemeBool(Handle, partId, stateId, (int)propId, out var b).Succeeded)
				return b;
			else if (propId == BoolProperty.FlatMenus)
				return GetThemeSysBool(Handle, (int)propId);
			return null;
		}

		/// <summary>Retrieves the value of a color property.</summary>
		/// <param name="partId">Value that specifies the part that contains the color property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the color property.</param>
		/// <param name="propId">The color property identifier.</param>
		/// <returns>The requested color value, if successful; otherwise <c>null</c>.</returns>
		public Color? GetColor(int partId, int stateId, ColorProperty propId) => GetThemeColor(Handle, partId, stateId, (int)propId, out var cr).Succeeded ? (Color?)cr : null;

		/// <summary>Retrieves a data stream corresponding to this theme, starting from a specified part and state.</summary>
		/// <param name="hInst">The SafeLibraryHandle of a loaded styles file.</param>
		/// <param name="partId">Specifies the part to retrieve a stream from.</param>
		/// <param name="stateId">Specifies the state of the part.</param>
		/// <returns>The data stream.</returns>
		public byte[] GetDiskStream(HINSTANCE hInst, int partId, int stateId)
		{
			var r = GetThemeStream(Handle, partId, stateId, (int)ThemeProperty.TMT_DISKSTREAM, out var bytes, out var bLen, hInst);
			if (r.Succeeded) return bytes.ToArray<byte>((int)bLen);
			if (r != 0x80070490) throw new InvalidOperationException("Bad GetThemeStream");
			return null;
		}

		/// <summary>Retrieves the value of a enum property.</summary>
		/// <param name="partId">Value that specifies the part that contains the enum property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the enum property.</param>
		/// <param name="propId">The enum property identifier.</param>
		/// <returns>The requested enum value, if successful; otherwise <c>null</c>.</returns>
		public int? GetEnumValue(int partId, int stateId, EnumProperty propId) => GetThemeEnumValue(Handle, partId, stateId, (int)propId, out var i).Succeeded ? (int?)i : null;

		/// <summary>Retrieves the value of a enum property.</summary>
		/// <param name="partId">Value that specifies the part that contains the enum property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the enum property.</param>
		/// <param name="propId">The enum property identifier.</param>
		/// <returns>The requested enum value, if successful; otherwise <c>null</c>.</returns>
		public T? GetEnumValue<T>(int partId, int stateId, EnumProperty propId) where T : struct, IComparable => GetThemeEnumValue(Handle, partId, stateId, (int)propId, out var i).Succeeded ? (T?)(object)i : null;

		/// <summary>Retrieves the value of a string property.</summary>
		/// <param name="partId">Value that specifies the part that contains the string property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the string property.</param>
		/// <param name="propId">The string property identifier.</param>
		/// <returns>The requested string value, if successful; otherwise <c>null</c>.</returns>
		public string GetFilename(int partId, int stateId, FilenameProperty propId)
		{
			const int sbLen = 1024;
			var sb = new StringBuilder(sbLen);
			return GetThemeFilename(Handle, partId, stateId, (int)propId, sb, sbLen).Succeeded ? sb.ToString() : null;
		}

		/// <summary>Retrieves the value of a font property.</summary>
		/// <param name="graphics">The device context from which to get the property.</param>
		/// <param name="partId">Value that specifies the part that contains the font property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the font property.</param>
		/// <param name="propId">The font property identifier.</param>
		/// <returns>The requested font value, if successful; otherwise <c>null</c>.</returns>
		public Font GetFont(IDeviceContext graphics, int partId, int stateId, FontProperty propId)
		{
			using (var hdc = new SafeHDC(graphics))
			{
				if (GetThemeFont(Handle, hdc, partId, stateId, (int)propId, out var f).Succeeded)
					return Font.FromLogFont(f);
				return GetThemeSysFont(Handle, (int)propId, out f).Succeeded ? Font.FromLogFont(f) : null;
			}
		}

		/// <summary>Retrieves the value of an int property.</summary>
		/// <param name="partId">Value that specifies the part that contains the int property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the int property.</param>
		/// <param name="propId">The int property identifier.</param>
		/// <returns>The requested int value, if successful; otherwise <c>null</c>.</returns>
		public int? GetInt(int partId, int stateId, IntProperty propId)
		{
			if (GetThemeInt(Handle, partId, stateId, (int)propId, out var i).Succeeded)
				return i;
			return GetThemeSysInt(Handle, (int)propId, out var si).Succeeded ? (int?)si : null;
		}

		/// <summary>Retrieves a list of <c>int</c> data from a visual style.</summary>
		/// <param name="partId">Value that specifies the part that contains the list of data to return.</param>
		/// <param name="stateId">Value that specifies the state of the part.</param>
		/// <param name="propId">Value that specifies the property to retrieve.</param>
		/// <returns>The requested list of data, if successful; otherwise <c>null</c>.</returns>
		public int[] GetIntList(int partId, int stateId, int propId = (int)ThemeProperty.TMT_TRANSITIONDURATIONS) => GetThemeIntList(Handle, partId, stateId, propId);

		/// <summary>Retrieves the margins from a visual style.</summary>
		/// <param name="graphics">The device context from which to get the property.</param>
		/// <param name="partId">Value that specifies the part that contains the margins to return.</param>
		/// <param name="stateId">Value that specifies the state of the part.</param>
		/// <param name="propId">Value that specifies the property to retrieve.</param>
		/// <returns>The requested margins, if successful; otherwise <c>null</c>.</returns>
		public Padding? GetMargins(IDeviceContext graphics, int partId, int stateId, MarginsProperty propId)
		{
			using (var hdc = new SafeHDC(graphics))
				return GetThemeMargins(Handle, hdc, partId, stateId, (int)propId, null, out var m).Succeeded ? (Padding?)new Padding(m.cxLeftWidth, m.cyTopHeight, m.cxRightWidth, m.cyBottomHeight) : null;
		}

		/// <summary>Retrieves the value of a metric property.</summary>
		/// <param name="graphics">The device context from which to get the property.</param>
		/// <param name="partId">Value that specifies the part that contains the metric property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the metric property.</param>
		/// <param name="propId">The metric property identifier.</param>
		/// <returns>The requested metric value, if successful; otherwise <c>null</c>.</returns>
		public int? GetMetric(IDeviceContext graphics, int partId, int stateId, MetricProperty propId)
		{
			using (var hdc = new SafeHDC(graphics))
				return GetThemeMetric(Handle, hdc, partId, stateId, (int)propId, out var i).Succeeded ? (int?)i : null;
		}

		/// <summary>Retrives the value of a property</summary>
		/// <param name="graphics">The device context from which to get the property.</param>
		/// <param name="partId">Value that specifies the part that contains the property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the property.</param>
		/// <param name="propId">The property identifier.</param>
		/// <returns>The requested value, if successful; otherwise <c>null</c>.</returns>
		public object GetObject(IDeviceContext graphics, int partId, int stateId, int propId)
		{
			object o = null;
			try
			{
				switch (LookupGetType(propId))
				{
					case PropertyType.Enum:
						o = GetEnumValue(partId, stateId, (EnumProperty)propId);
						break;
					case PropertyType.String:
						o = GetString(partId, stateId, (StringProperty)propId);
						break;
					case PropertyType.Int:
					case PropertyType.SysInt:
						o = GetInt(partId, stateId, (IntProperty)propId);
						break;
					case PropertyType.Metric:
						o = GetMetric(graphics, partId, stateId, (MetricProperty)propId);
						break;
					case PropertyType.Bool:
						o = GetBool(partId, stateId, (BoolProperty)propId);
						break;
					case PropertyType.Color:
						o = GetColor(partId, stateId, (ColorProperty)propId);
						break;
					case PropertyType.Margins:
						o = GetMargins(graphics, partId, stateId, (MarginsProperty)propId);
						break;
					case PropertyType.FileName:
						o = GetFilename(partId, stateId, (FilenameProperty)propId);
						break;
					case PropertyType.Size:
						o = GetPartSize(graphics, partId, stateId, null, (PartSize)propId);
						break;
					case PropertyType.Position:
						o = GetPosition(partId, stateId, (PositionProperty)propId);
						break;
					case PropertyType.Rect:
						o = GetRect(partId, stateId, (RectangleProperty)propId);
						break;
					case PropertyType.Font:
						o = GetFont(graphics, partId, stateId, (FontProperty)propId);
						break;
					case PropertyType.IntList:
						o = GetIntList(partId, stateId, propId);
						break;
					case PropertyType.HBitmap:
						o = GetBitmap(partId, stateId, (BitmapProperty)propId);
						break;
					//case PropertyType.DiskStream:
					//	o = GetDiskStream(partId, stateId);
					//	break;
					case PropertyType.Stream:
						o = GetStream(partId, stateId);
						break;
					default:
						System.Diagnostics.Debug.WriteLine($"Failed to get value for {partId}:{stateId}:{propId}.");
						break;
				}
			}
			catch (Exception ex)
			{
				o = ex;
				System.Diagnostics.Debug.WriteLine($"Failed to get value for {partId}:{stateId}:{propId}.");
			}
			return o;
		}

		/// <summary>Calculates the original size of the part defined by a visual style.</summary>
		/// <param name="graphics">The device context to select fonts into.</param>
		/// <param name="partId">Value that specifies the part to calculate the size of.</param>
		/// <param name="stateId">Value that specifies the state of the part.</param>
		/// <param name="destRect">The rectangle used for the part drawing destination. This parameter may be set to <c>null</c>.</param>
		/// <param name="size">Specifies the type of size to retrieve.</param>
		/// <returns>The dimensions of the specified part.</returns>
		public Size? GetPartSize(IDeviceContext graphics, int partId, int stateId, Rectangle? destRect = null, PartSize size = PartSize.Default)
		{
			using (var hdc = new SafeHDC(graphics))
				return GetThemePartSize(Handle, hdc, partId, stateId, destRect, (THEMESIZE)size, out var sz).Succeeded ? (Size?)sz : null;
		}

		/// <summary>Retrieves the value of a position property.</summary>
		/// <param name="partId">Value that specifies the part that contains the position property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the position property.</param>
		/// <param name="propId">The position property identifier.</param>
		/// <returns>The requested position value, if successful; otherwise <c>null</c>.</returns>
		public Point? GetPosition(int partId, int stateId, PositionProperty propId) => GetThemePosition(Handle, partId, stateId, (int)propId, out var i).Succeeded ? (Point?)i : null;

		/// <summary>Retrieves the location of the theme property definition for a property.</summary>
		/// <param name="partId">Value of type int that specifies the part that contains the theme. See Parts and States.</param>
		/// <param name="stateId">Value of type int that specifies the state of the part. See Parts and States.</param>
		/// <param name="propId">Value of type int that specifies the property to retrieve. You may use any of the property enum value cast to an <c>int</c>.</param>
		/// <returns>Value that indicates where the property was or was not found.</returns>
		public PropertyOrigin GetPropertyOrigin(int partId, int stateId, int propId) => GetThemePropertyOrigin(Handle, partId, stateId, propId, out var po).Succeeded ? (PropertyOrigin)po : PropertyOrigin.NotFound;

		/// <summary>Retrieves the value of a rectangle property.</summary>
		/// <param name="partId">Value that specifies the part that contains the rectangle property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the rectangle property.</param>
		/// <param name="propId">The rectangle property identifier.</param>
		/// <returns>The requested rectangle value, if successful; otherwise <c>null</c>.</returns>
		public Rectangle? GetRect(int partId, int stateId, RectangleProperty propId) => GetThemeRect(Handle, partId, stateId, (int)propId, out var rc).Succeeded ? (Rectangle?)rc : null;

		/// <summary>Retrieves a data stream corresponding to this theme, starting from a specified part and state.</summary>
		/// <param name="partId">Specifies the part to retrieve a stream from.</param>
		/// <param name="stateId">Specifies the state of the part.</param>
		/// <returns>The data stream.</returns>
		public byte[] GetStream(int partId, int stateId)
		{
			var r = GetThemeStream(Handle, partId, stateId, (int)ThemeProperty.TMT_STREAM, out var bytes, out var bLen, HINSTANCE.NULL);
			if (r.Succeeded) return bytes.ToArray<byte>((int)bLen);
			if (r != 0x80070490) throw new InvalidOperationException("Bad GetThemeStream");
			return null;
		}

		/// <summary>Retrieves the value of a string property.</summary>
		/// <param name="partId">Value that specifies the part that contains the string property.</param>
		/// <param name="stateId">Value that specifies the state of the part that contains the string property.</param>
		/// <param name="propId">The string property identifier.</param>
		/// <returns>The requested string value, if successful; otherwise <c>null</c>.</returns>
		public string GetString(int partId, int stateId, StringProperty propId)
		{
			const int sbLen = 1024;
			var sb = new StringBuilder(sbLen);
			if (GetThemeString(Handle, partId, stateId, (int)propId, sb, sbLen).Succeeded)
				return sb.ToString();
			sb = new StringBuilder(sbLen);
			return GetThemeSysString(Handle, (int)propId, sb, sbLen).Succeeded ? sb.ToString() : null;
		}

		/// <summary>Retrieves a system color brush.</summary>
		/// <param name="colorId">Value that specifies the color number.</param>
		/// <returns>Handle to brush data.</returns>
		public Brush GetSystemBrush(SystemColorIndex colorId)
		{
			var hbrush = GetThemeSysColorBrush(Handle, (int)colorId);
			return !hbrush.IsInvalid ? hbrush.ToBrush() : null;
		}

		/// <summary>Retrieves the value of a system color.</summary>
		/// <param name="colorId">Value that specifies the color number.</param>
		/// <returns>The value of the specified system color.</returns>
		public Color GetSystemColor(SystemColorIndex colorId) => GetThemeSysColor(Handle, colorId);

		/// <summary>Gets the system font.</summary>
		/// <param name="fontId">The font property identifier.</param>
		/// <returns>The value of the specified font.</returns>
		public Font GetSystemFont(int fontId) => GetThemeSysFont(Handle, fontId, out var lf).Succeeded ? Font.FromLogFont(lf) : null;

		/// <summary>Retrieves the value of a system size metric from theme data.</summary>
		/// <param name="metric">Value that specifies the system size metric desired.</param>
		/// <returns>Returns the size in pixels.</returns>
		public int GetSystemMetric(User32.SystemMetric metric) => GetThemeSysSize(Handle, (int)metric);

		/// <summary>Calculates the size and location of the specified text when rendered in the visual style font.</summary>
		/// <param name="dc">
		/// <para>HDC to select the font into.</para>
		/// </param>
		/// <param name="partId">
		/// <para>Value that specifies the part in which the text will be drawn. See Parts and States.</para>
		/// </param>
		/// <param name="stateId">
		/// <para>Value that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="text">
		/// <para>A string that contains the text to draw.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Enumeration value that contains one or more values that specify the string's formatting.</para>
		/// </param>
		/// <param name="bounds">
		/// <para>The rectangle used to control layout of the text. This parameter may be set to <see langword="null"/>.</para>
		/// </param>
		/// <returns>
		/// <para>In logical coordinates, the rectangle required to fit the rendered text.</para>
		/// </returns>
		public Rectangle? GetTextExtent(IDeviceContext dc, int partId, int stateId, string text, DrawTextFlags flags, Rectangle? bounds)
		{
			using (var hdc = new SafeHDC(dc))
				return GetThemeTextExtent(Handle, hdc, partId, stateId, text, -1, flags, bounds, out var ext).Succeeded ? (Rectangle?)ext : null;
		}

		/// <summary>Retrieves information about the font specified by a visual style for a particular part.</summary>
		/// <param name="dc">
		/// <para>HDC to use for screen context. This parameter may be set to <see langword="null"/>.</para>
		/// </param>
		/// <param name="partId">
		/// <para>Value that specifies the part to retrieve font information about. See Parts and States.</para>
		/// </param>
		/// <param name="stateId">
		/// <para>Value that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <returns>
		/// <para>Receives the font information.</para>
		/// </returns>
		public TEXTMETRIC? GetTextMetrics(IDeviceContext dc, int partId, int stateId)
		{
			using (var hdc = new SafeHDC(dc))
				return GetThemeTextMetrics(Handle, hdc, partId, stateId, out var m).Succeeded ? (TEXTMETRIC?)m : null;
		}

		/// <summary>Gets the duration for the specified transition.</summary>
		/// <param name="partId">ID of the part.</param>
		/// <param name="fromStateId">State ID of the part before the transition.</param>
		/// <param name="toStateId">State ID of the part after the transition.</param>
		/// <returns>The transition duration.</returns>
		public TimeSpan? GetTransitionDuration(int partId, int fromStateId, int toStateId) =>
			GetThemeTransitionDuration(Handle, partId, fromStateId, toStateId, (int)ThemeProperty.TMT_TRANSITIONDURATIONS, out var dur).Succeeded ? (TimeSpan?)TimeSpan.FromMilliseconds(dur) : null;

		/// <summary>Retrieves whether the background specified by the visual style has transparent pieces or alpha-blended pieces.</summary>
		/// <param name="partId">Value of type <c>int</c> that specifies the part.</param>
		/// <param name="stateId">Value of type <c>int</c> that specifies the state of the part.</param>
		/// <returns>
		/// <see langword="true"/> if the theme-specified background for a particular partId and stateId has transparent pieces or alpha-blended pieces;
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool IsBackgroundPartiallyTransparent(int partId, int stateId) => IsThemeBackgroundPartiallyTransparent(Handle, partId, stateId);

		/// <summary>Retrieves whether a visual style has defined parameters for the specified part and state.</summary>
		/// <param name="partId">Value that specifies the part.</param>
		/// <returns><see langword="true"/> if the theme has defined parameters for the specified part; <see langword="false"/> otherwise.</returns>
		public bool IsPartDefined(int partId) => IsThemePartDefined(Handle, partId, 0);

		private static PropertyType LookupGetType(int propId)
		{
			if ((propId >= 4001 && propId <= 4015))
				return PropertyType.Enum;
			if ((propId >= 401 && propId <= 402) || (propId >= 600 && propId <= 608) || (propId >= 1401 && propId <= 1404) ||
				(propId >= 3201 && propId <= 3202) || propId == 8001)
				return PropertyType.String;
			if (propId == 403 || (propId >= 1201 && propId <= 1210) || (propId >= 1801 && propId <= 1810) || propId == 5006)
				return PropertyType.Int;
			if (propId >= 2401 && propId <= 2434 && propId != 2431)
				return PropertyType.Metric;
			if (propId == 1301)
				return PropertyType.SysInt;
			if (propId == 1001 || (propId >= 2201 && propId <= 2220) || propId == 5001 || propId == 7001)
				return PropertyType.Bool;
			if ((propId >= 1601 && propId <= 1631) || (propId >= 2001 && propId <= 2010) || propId == 2431 ||
				(propId >= 3801 && propId <= 3827) || propId == 5003)
				return PropertyType.Color;
			if ((propId >= 3601 && propId <= 3603))
				return PropertyType.Margins;
			if ((propId >= 3001 && propId <= 3010))
				return PropertyType.FileName;
			if ((propId >= 0 && propId <= 2))
				return PropertyType.Size;
			if ((propId >= 3401 && propId <= 3411))
				return PropertyType.Position;
			if (propId == 5002 || propId == 5004 || propId == 5005 || propId == 8002)
				return PropertyType.Rect;
			if ((propId >= 801 && propId <= 809) || propId == 2601)
				return PropertyType.Font;
			if (propId == 6000)
				return PropertyType.IntList;
			if ( /*propId == 2 ||*/ propId == 8)
				return PropertyType.HBitmap;
			if (propId == 8000 || propId == (int)PropertyType.DiskStream)
				return PropertyType.DiskStream;
			if (propId == (int)PropertyType.Stream)
				return PropertyType.Stream;
			System.Diagnostics.Debug.WriteLine($"Unmapped theme property: {propId}");
			return PropertyType.Unknown;
		}
	}
}