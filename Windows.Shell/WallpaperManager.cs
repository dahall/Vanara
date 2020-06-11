using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Specifies how the desktop wallpaper should be displayed.</summary>
	public enum WallpaperFit
	{
		/// <summary>Center the image; do not stretch.</summary>
		Center,

		/// <summary>Tile the image across all monitors.</summary>
		Tile,

		/// <summary>Stretch the image to exactly fit on the monitor.</summary>
		Stretch,

		/// <summary>
		/// Stretch the image to exactly the height or width of the monitor without changing its aspect ratio or cropping the image. This
		/// can result in colored letterbox bars on either side or on above and below of the image.
		/// </summary>
		Fit,

		/// <summary>Stretch the image to fill the screen, cropping the image as necessary to avoid letterbox bars.</summary>
		Fill,

		/// <summary>Spans a single image across all monitors attached to the system.</summary>
		Span,
	}

	/// <summary>Provides methods for managing the desktop wallpaper.</summary>
	public static class WallpaperManager
	{
		[ThreadStatic]
		private static ComReleaser<IDesktopWallpaper> pWallpaper;

		/// <summary>
		/// Sets the color that is visible on the desktop when no image is displayed or when the desktop background has been disabled. This
		/// color is also used as a border when the desktop wallpaper does not fill the entire screen.
		/// </summary>
		/// <value>A value that specifies the background RGB color value.</value>
		public static Color BackgroundColor
		{
			get => Wallpaper.GetBackgroundColor();
			set => Wallpaper.SetBackgroundColor(value);
		}

		/// <summary>Enables or disables the desktop background.</summary>
		/// <value><see langword="true"/> to enable the desktop background, <see langword="false"/> to disable it.</value>
		public static bool Enabled
		{
			get => Status.IsFlagSet(DESKTOP_SLIDESHOW_STATE.DSS_ENABLED);
			set => Wallpaper.Enable(value);
		}

		/// <summary>The monitors that are associated with the system.</summary>
		/// <value>A list of system monitors.</value>
		public static IReadOnlyList<WallpaperMonitor> Monitors { get; } = new WallpaperMonitors();

		/// <summary>Gets an object that controls the wallpaper slideshow options.</summary>
		/// <value>The slideshow options object.</value>
		public static WallpaperSlideshow Slideshow { get; } = new WallpaperSlideshow();

		/// <summary>
		/// Gets or sets the display option for the desktop wallpaper image, determining whether the image should be centered, tiled, or stretched.
		/// </summary>
		/// <value>An enumeration value that specify how the image will be displayed on the system's monitors.</value>
		public static WallpaperFit WallpaperFit
		{
			get => (WallpaperFit)Wallpaper.GetPosition();
			set => Wallpaper.SetPosition((DESKTOP_WALLPAPER_POSITION)value);
		}

		internal static DESKTOP_SLIDESHOW_STATE Status => Wallpaper.GetStatus();

		private static IDesktopWallpaper Wallpaper => pWallpaper?.Item ?? (pWallpaper = ComReleaserFactory.Create(new IDesktopWallpaper())).Item;

		/// <summary>Sets the wallpaper to a single picture.</summary>
		/// <param name="imagePath">The full path to the image file. This file must exist and be a picture format (jpg, gif, etc.).</param>
		/// <param name="fit">The display option for the desktop wallpaper image.</param>
		/// <param name="monitorIndex">
		/// The index of the monitor on which to set the wallpaper. Any value less than 0 will cause the picture to be set for all monitors.
		/// </param>
		/// <exception cref="FileNotFoundException"/>
		public static void SetPicture(string imagePath, WallpaperFit fit, int monitorIndex = -1)
		{
			if (!File.Exists(imagePath)) throw new FileNotFoundException();
			Enabled = true;
			Slideshow.Images = null;
			Wallpaper.SetWallpaper(monitorIndex < 0 ? null : Monitors[monitorIndex].Id, imagePath);
			WallpaperFit = fit;
		}

		/// <summary>Sets the wallpaper to display a slideshow of all images within the specified directory.</summary>
		/// <param name="folderPath">The full path to the folder that contains the images to use in the slideshow.</param>
		/// <param name="fit">The display option for the displayed image.</param>
		/// <param name="interval">
		/// If specified, the amount of time between image transitions. Specifying <see langword="null"/> will ignore setting this value and
		/// any previous setting will stay in place.
		/// </param>
		/// <param name="shuffle">
		/// If specified, determined if the items in <paramref name="folderPath"/> will be shuffled. Specifying <see langword="null"/> will
		/// ignore setting this value and any previous setting will stay in place.
		/// </param>
		/// <exception cref="DirectoryNotFoundException"/>
		public static void SetSlideshow(string folderPath, WallpaperFit fit, TimeSpan? interval = null, bool? shuffle = false)
		{
			if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException();
			Enabled = true;
			Slideshow.Images = (IReadOnlyList<ShellItem>)new List<ShellItem>() { new ShellItem(folderPath) };
			WallpaperFit = fit;
			if (interval.HasValue) Slideshow.Interval = interval.Value;
			if (shuffle.HasValue) Slideshow.Shuffle = shuffle.Value;
		}

		/// <summary>Sets the background to a solid color with no displayed image.</summary>
		/// <param name="color">
		/// If specified, the color of the background. Specifying <see langword="null"/> will ignore setting this value and any previous
		/// setting will stay in place.
		/// </param>
		public static void SetSolidBackground(Color? color = null)
		{
			Enabled = false;
			Wallpaper.SetWallpaper(null, "");
			Slideshow.Images = null;
			WallpaperFit = WallpaperFit.Fill;
			if (color.HasValue) BackgroundColor = color.Value;
		}

		/// <summary>Represents the wallpaper settings on a single monitor.</summary>
		public class WallpaperMonitor
		{
			/// <summary>Retrieves the display rectangle of the monitor.</summary>
			/// <value>The display rectangle.</value>
			public Rectangle DisplayRectangle => Wallpaper.GetMonitorRECT(Id, out var r) == HRESULT.S_OK ? (Rectangle)r : Rectangle.Empty;

			/// <summary>Gets the identifier of the monitor.</summary>
			/// <value>The monitor identifier.</value>
			public string Id { get; internal set; }

			/// <summary>
			/// The path to the wallpaper image file. Note that this image could be currently displayed on all of the system's monitors, not
			/// just this monitor.
			/// </summary>
			/// <value>The image path.</value>
			public string ImagePath
			{
				get => Wallpaper.GetWallpaper(Id, out var img).Succeeded ? img : null;
				set => Wallpaper.SetWallpaper(Id, value ?? string.Empty);
			}

			/// <inheritdoc/>
			public override string ToString() => $"{Id}: Rect={DisplayRectangle}, Path={ImagePath}";
		}

		/// <summary>Represents the settings for a wallpaper slideshow.</summary>
		public class WallpaperSlideshow
		{
			/// <summary>Gets or sets the images that are being displayed in the desktop wallpaper slideshow.</summary>
			public IReadOnlyList<ShellItem> Images
			{
				get
				{
					try
					{
						var shArray = Wallpaper.GetSlideshow();
						return new ShellItemArray(shArray);
					}
					catch
					{
						return (IReadOnlyList<ShellItem>)new List<ShellItem>();
					}
				}

				set
				{
					var shArray = value as ShellItemArray ?? (value is null || value.Count == 0 ? new ShellItemArray() : new ShellItemArray(value));
					switch (shArray.Count)
					{
						case 0:
							break;

						case 1:
							if (!shArray[0].IsFolder)
								throw new ArgumentException("In a list with only one item, that item must be a container.", nameof(Images));
							break;

						default:
							var parent = shArray[0].Parent;
							if (shArray.Any(shi => shi.IsFolder || shi.Parent != parent))
								throw new ArgumentException("In a list with more than one item, all items must be image paths in the same container.", nameof(Images));
							break;
					}
					Wallpaper.SetSlideshow(shArray.IShellItemArray);
				}
			}

			/// <summary>Gets or sets the amount of time between image transitions.</summary>
			/// <value>The interval between transitions.</value>
			public TimeSpan Interval
			{
				get { Wallpaper.GetSlideshowOptions(out _, out var tick); return TimeSpan.FromMilliseconds(tick); }
				set => Wallpaper.SetSlideshowOptions(Shuffle ? DESKTOP_SLIDESHOW_OPTIONS.DSO_SHUFFLEIMAGES : 0, (uint)value.TotalMilliseconds);
			}

			/// <summary>Gets a value indicating whether the slideshow is enabled.</summary>
			/// <value><see langword="true"/> if the slideshow is enabled; otherwise, <see langword="false"/>.</value>
			public bool IsEnabled => Status.IsFlagSet(DESKTOP_SLIDESHOW_STATE.DSS_SLIDESHOW);

			/// <summary>Gets or sets a value indicating whether the images in the slideshow are shuffled.</summary>
			/// <value><see langword="true"/> if images are shuffled; otherwise, <see langword="false"/>.</value>
			public bool Shuffle
			{
				get { Wallpaper.GetSlideshowOptions(out var opt, out _); return opt == DESKTOP_SLIDESHOW_OPTIONS.DSO_SHUFFLEIMAGES; }
				set => Wallpaper.SetSlideshowOptions(value ? DESKTOP_SLIDESHOW_OPTIONS.DSO_SHUFFLEIMAGES : 0, (uint)Interval.TotalMilliseconds);
			}

			/// <summary>Switches the wallpaper on a specified monitor to the next image in the slideshow.</summary>
			/// <param name="forward">
			/// If set to <see langword="true"/>, advances the slideshow forward. If <see langword="false"/>, advances backwards.
			/// </param>
			/// <param name="monitorIndex">
			/// The index of the monitor on which to set the wallpaper. Any value less than 0 will cause the picture to be set for all monitors.
			/// </param>
			public void Advance(bool forward = true, int monitorIndex = -1) =>
				Wallpaper.AdvanceSlideshow(monitorIndex < 0 ? null : Monitors[monitorIndex].Id, forward ? DESKTOP_SLIDESHOW_DIRECTION.DSD_FORWARD : DESKTOP_SLIDESHOW_DIRECTION.DSD_BACKWARD);
		}

		private class WallpaperMonitors : IReadOnlyList<WallpaperMonitor>
		{
			public int Count => (int)Wallpaper.GetMonitorDevicePathCount();

			public WallpaperMonitor this[string id] => new WallpaperMonitor { Id = id };

			public WallpaperMonitor this[int index] => this[Wallpaper.GetMonitorDevicePathAt((uint)index, out var id).Succeeded ? id : throw new ArgumentOutOfRangeException(nameof(index))];

			public IEnumerator<WallpaperMonitor> GetEnumerator()
			{
				for (var i = 0; i < Count; i++)
					yield return this[i];
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}