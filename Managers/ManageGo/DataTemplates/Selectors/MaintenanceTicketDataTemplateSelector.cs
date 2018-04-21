using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class MaintenanceTicketDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case MaintenanceTicketSectionHeaderViewModel _:
                    return MaintenanceTicketSectionHeaderCell.Template;
                case MaintenanceTicketDetailsViewModel _:
                    return MaintenanceTicketDetailsCell.Template;
                default:
                    throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
            }
        }
    }
}

