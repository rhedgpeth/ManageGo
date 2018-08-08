using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using ManageGo.DataTemplates.Selectors;

namespace ManageGo.Pages
{
    public partial class MaintenanceTicketPage : BaseContentPage<MaintenanceTicketViewModel>
    {
        public MaintenanceTicketPage()
        {
            InitializeComponent();
			listView.ItemTemplate = new MaintenanceTicketDetailDataTemplateSelector();
        }
    }
}
