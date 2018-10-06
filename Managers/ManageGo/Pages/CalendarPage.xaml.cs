using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class CalendarPage : BaseContentPage<CalendarViewModel>
    {
        public CalendarPage()
        {
            InitializeComponent();

			listView.ItemTemplate = new CalendarDataTemplateSelector();
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

            if (e.SelectedItem is CalendarSectionHeaderViewModel section)
            {
                var viewModel = BindingContext as CalendarViewModel;
                viewModel?.OnSectionHeaderSelected(section);
            }
        }
    }
}
