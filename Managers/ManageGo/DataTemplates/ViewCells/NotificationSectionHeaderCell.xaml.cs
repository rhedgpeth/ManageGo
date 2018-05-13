using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class NotificationSectionHeaderCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(NotificationSectionHeaderCell));

        public NotificationSectionHeaderCell()
        {
            InitializeComponent();
        }
    }
}
