using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class MaintenanceTicketDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(MaintenanceTicketDetailsCell));

        public MaintenanceTicketDetailsCell()
        {
            InitializeComponent();
        }
    }
}
