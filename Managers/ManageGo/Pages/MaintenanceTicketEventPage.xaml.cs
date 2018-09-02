using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
	public partial class MaintenanceTicketEventPage : BasePopupPage<MaintenanceTicketEventViewModel>
    {
        public MaintenanceTicketEventPage()
        {
            InitializeComponent();

            var cb = new Plugin.InputKit.Shared.Controls.CheckBox();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            participantsLayout.IsVisible = !participantsLayout.IsVisible;
        }
	}
}
