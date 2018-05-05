using System;
using ManageGo.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace ManageGo.iOS.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
			var cell = base.GetCell(item, reusableCell, tv);

			if (cell != null)
				cell.SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
	      
            return cell;
        }
    }
}
