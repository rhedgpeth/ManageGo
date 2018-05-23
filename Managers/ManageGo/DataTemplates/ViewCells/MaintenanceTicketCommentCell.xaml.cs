using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class MaintenanceTicketCommentCell : ViewCell
    {      
		public static readonly DataTemplate Template = new DataTemplate(typeof(MaintenanceTicketCommentCell));

        public MaintenanceTicketCommentCell()
        {
            InitializeComponent();
        }
    }
}
