using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class NotificationDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(NotificationDetailsCell));

        public NotificationDetailsCell()
        {
            InitializeComponent();
        }
    }
}
