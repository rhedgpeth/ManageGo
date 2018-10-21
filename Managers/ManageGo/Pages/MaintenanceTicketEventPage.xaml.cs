using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
	public partial class MaintenanceTicketEventPage : BasePopupPage<MaintenanceTicketEventViewModel>
    {
        public MaintenanceTicketEventPage()
        {
            InitializeComponent();
        }

        void Handle_Users_Clicked(object sender, EventArgs e)
        {
            SendToUsersLayout.IsVisible = !SendToUsersLayout.IsVisible;
            SendToContactsLayout.IsVisible = false;
        }

        void Handle_Contacts_Clicked(object sender, EventArgs e)
        {
            SendToContactsLayout.IsVisible = !SendToContactsLayout.IsVisible;
            SendToUsersLayout.IsVisible = false;
        }
    }
}
