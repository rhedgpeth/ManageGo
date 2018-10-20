using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class TransactionsPage : BaseSearchContentPage<TransactionsViewModel,object>
    {
		public TransactionsPage()
        {
            InitializeComponent();
            listView.ItemTemplate = new TransactionDataTemplateSelector();
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

            if (e.SelectedItem is TransactionSectionHeaderViewModel section)
            {
                var viewModel = BindingContext as TransactionsViewModel;
                viewModel?.OnSectionHeaderSelected(section);
            }
        }

        void Handle_OnPresetRangeUpdate(object sender, System.EventArgs e) => filterView.ApplyFilter();
    }
}
