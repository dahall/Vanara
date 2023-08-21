using System.Windows.Forms;

namespace Vanara.Windows.Shell;

public partial class ThumbnailToolbarButton
{
	internal class ImageIndexer
	{
		private int index = -1;
		private string key = string.Empty;
		private bool useIntegerIndex = true;

		public virtual int ActualIndex => useIntegerIndex ? Index : (ImageList is null ? -1 : ImageList.Images.IndexOfKey(Key));

		public virtual ImageList? ImageList { get; set; }

		public virtual int Index
		{
			get => index;
			set
			{
				key = string.Empty;
				index = value;
				useIntegerIndex = true;
			}
		}

		public virtual string? Key
		{
			get => key;
			set
			{
				index = -1;
				key = value ?? string.Empty;
				useIntegerIndex = false;
			}
		}
	}
}
