using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class MaintenanceTicketDetailDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case MaintenanceTicketActionViewModel _:
                    return MaintenanceTicketActionCell.Template;
                case MaintenanceTicketCommentViewModel _:
                    return MaintenanceTicketCommentCell.Template;
                default:
                    throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
            }
        }
    }
}
