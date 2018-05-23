using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class MaintenanceTicketPage : BaseSearchContentPage<MaintenanceTicketViewModel>
    {
        public MaintenanceTicketPage()
        {
            InitializeComponent();
			listView.ItemTemplate = new MaintenanceTicketDetailDataTemplateSelector();
        }
    }
}
