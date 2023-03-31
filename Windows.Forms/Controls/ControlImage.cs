using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vanara.Windows.Forms;

/// <summary>Represents an image used within a control.</summary>
public class ControlImage
{
	private Image image;
	private string imageKey = string.Empty;
	private ImageList imageList;
	private int index = -1;
	private bool useIntegerIndex = true;

	/// <summary>Initializes a new instance of the <see cref="ControlImage"/> class.</summary>
	/// <param name="parent">The parent.</param>
	public ControlImage(Control parent) { Control = parent; }

	/// <summary>Gets or sets the image.</summary>
	/// <value>The image.</value>
	public virtual Image Image
	{
		get
		{
			if ((image == null) && (imageList != null))
			{
				int actualIndex = ActualIndex;
				if (actualIndex >= imageList.Images.Count)
					actualIndex = imageList.Images.Count - 1;
				if (actualIndex >= 0)
					return imageList.Images[actualIndex];
			}
			return image;
		}
		set
		{
			if (image == value) return;
			image = value;
			if (image != null)
			{
				ImageIndex = -1;
				ImageList = null;
				Control?.Invalidate();
			}
		}
	}

	/// <summary>Gets or sets the index of the image.</summary>
	/// <value>The index of the image.</value>
	/// <exception cref="System.ArgumentOutOfRangeException">ImageIndex</exception>
	public virtual int ImageIndex
	{
		get
		{
			if ((index != -1) && (imageList != null) && (index >= imageList.Images.Count))
				return imageList.Images.Count - 1;
			return index;
		}
		set
		{
			if (value < -1) throw new ArgumentOutOfRangeException(nameof(ImageIndex));
			if (index == value) return;
			if (value != -1) image = null;
			imageKey = string.Empty;
			index = value;
			useIntegerIndex = true;
			Control?.Invalidate();
		}
	}

	/// <summary>Gets or sets the image key.</summary>
	/// <value>The image key.</value>
	public virtual string ImageKey
	{
		get => imageKey; set
		{
			if (imageKey == value) return;
			index = -1;
			if (value != null) image = null;
			imageKey = value ?? string.Empty;
			useIntegerIndex = false;
			Control?.Invalidate();
		}
	}

	/// <summary>Gets or sets the image list.</summary>
	/// <value>The image list.</value>
	public virtual ImageList ImageList
	{
		get => imageList; set
		{
			if (imageList == value) return;
			if (imageList != null)
				imageList.RecreateHandle -= ImageListOnRecreateHandle;
			if (value != null)
				image = null;
			imageList = value;
			if (imageList != null)
				imageList.RecreateHandle += ImageListOnRecreateHandle;
			Control?.Invalidate();
		}
	}

	/// <summary>Gets the actual index.</summary>
	/// <value>The actual index.</value>
	protected virtual int ActualIndex
	{
		get
		{
			if (useIntegerIndex)
				return ImageIndex;
			if (ImageList != null)
				return ImageList.Images.IndexOfKey(ImageKey);
			return -1;
		}
	}

	/// <summary>Gets or sets the control.</summary>
	/// <value>The control.</value>
	protected Control Control { get; set; }

	private void ImageListOnRecreateHandle(object sender, EventArgs eventArgs)
	{
		if (Control?.IsHandleCreated ?? false) Control.Invalidate();
	}
}