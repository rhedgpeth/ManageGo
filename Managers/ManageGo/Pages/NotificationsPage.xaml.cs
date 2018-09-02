using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class NotificationsPage : BaseContentPage<NotificationsViewModel> 
    {
        public NotificationsPage()
		{
            InitializeComponent();

            listView.ItemTemplate = new NotificationDataTemplateSelector();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemSelected += OnItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            listView.ItemSelected -= OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;

            if (e.SelectedItem is NotificationSectionHeaderViewModel section)
            {
                var viewModel = BindingContext as NotificationsViewModel;
                viewModel?.OnSectionHeaderSelected(section);
            }
        }
    }
}
