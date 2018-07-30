using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
	public partial class CreateEventPage : BasePopupPage<CreateEventViewModel>
    {
        public CreateEventPage()
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
