using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class TenantsPage : BaseSearchContentPage<TenantsViewModel,object>
    {
        public TenantsPage()
        {
            InitializeComponent();
			listView.ItemTemplate = new TenantDataTemplateSelector();
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

            if (e.SelectedItem is TenantSectionHeaderViewModel section)
            {
                var viewModel = BindingContext as TenantsViewModel;
                viewModel?.OnSectionHeaderSelected(section);
            }
        }
    }
}
