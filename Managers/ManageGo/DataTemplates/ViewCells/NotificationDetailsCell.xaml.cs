using ManageGo.Core.Managers.ViewModels;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class NotificationDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(NotificationDetailsCell));

        int _declineButtonTapCount;

        public NotificationDetailsCell()
        {
            InitializeComponent();
        }

        void DeclineButton_Unfocused(object sender, FocusEventArgs e)
        {
            _declineButtonTapCount = 0;

            declineButton.Text = "Decline";
            declineButton.BackgroundColor = (Color)Application.Current.Resources["Red"];
        }

        async void Handle_Declined_Clicked(object sender, System.EventArgs e)
        {
            declineButton.IsEnabled = false;

            _declineButtonTapCount++;

            if (_declineButtonTapCount >= 2)
            {
                var viewModel = BindingContext as NotificationDetailsViewModel;

                if (viewModel != null)
                {
                    await viewModel.UpdatePendingLeaseApproval(false);
                }
            }
            else
            {
                declineButton.Text = "Confirm";
                declineButton.BackgroundColor = Color.Black;

                declineButton.Focus();
            }

            declineButton.IsEnabled = true;
        }
    }
}
