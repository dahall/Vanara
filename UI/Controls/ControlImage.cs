using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public class ControlImage
	{
		private Image image;
		private string imageKey = string.Empty;
		private ImageList imageList;
		private int index = -1;
		private bool useIntegerIndex = true;

		public ControlImage(Control parent) { Control = parent; }

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

		protected Control Control { get; set; }

		private void ImageListOnRecreateHandle(object sender, EventArgs eventArgs) { if (Control?.IsHandleCreated ?? false) Control.Invalidate(); }
	}
}
