using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vanara.Windows.Shell.Tests;

public partial class ImageViewer : Form
{
	public ImageViewer(IEnumerable<Image> items = null) : this(items.Select(i => (i, "")))
	{
	}

	public ImageViewer(IEnumerable<(Image, string)> items = null)
	{
		InitializeComponent();
		BackColor = Color.Gray;
		if (items is null) return;
		foreach ((Image img, string tt) in items)
		{
			var p = new PictureBox { Size = img.Size, Image = img, BackColor = Color.Transparent };
			toolTip1.SetToolTip(p, tt);
			flow.Controls.Add(p);
		}
	}
}