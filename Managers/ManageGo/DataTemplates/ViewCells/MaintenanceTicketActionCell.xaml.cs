using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class MaintenanceTicketActionCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(MaintenanceTicketActionCell));

        public MaintenanceTicketActionCell()
        {
            InitializeComponent();
        }
    }
}
