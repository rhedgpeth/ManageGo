using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class MaintenanceTicketsPage : BaseSearchContentPage<MaintenanceTicketsViewModel,object>
    {
        public MaintenanceTicketsPage()
        {
			InitializeComponent();         
            listView.ItemTemplate = new MaintenanceTicketDataTemplateSelector();
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

            if (e.SelectedItem is MaintenanceTicketSectionHeaderViewModel section)
            {
				var viewModel = BindingContext as MaintenanceTicketsViewModel;
                viewModel?.OnSectionHeaderSelected(section);
            }
        }
    }
}
