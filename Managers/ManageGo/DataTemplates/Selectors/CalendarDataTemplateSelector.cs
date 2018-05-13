using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class CalendarDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case NotificationSectionHeaderViewModel _:
                    return CalendarSectionHeaderCell.Template;
                case NotificationDetailsViewModel _:
                    return CalendarDetailsCell.Template;
                default:
                    throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
            }
        }
    }
}
