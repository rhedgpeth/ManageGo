using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.Selectors;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
    public partial class PaymentsPage : BaseSearchContentPage<PaymentsViewModel,object>
    {      
        public PaymentsPage()
        {
            InitializeComponent();   
			listView.ItemTemplate = new PaymentDataTemplateSelector();
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
                     
			if (e.SelectedItem is PaymentSectionHeaderViewModel section)
			{
				var viewModel = BindingContext as PaymentsViewModel;            
                viewModel?.OnSectionHeaderSelected(section);
			}
		}
	}
}
