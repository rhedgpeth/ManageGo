using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class TenantDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case TenantSectionHeaderViewModel _:
                    return TenantSectionHeaderCell.Template;
                case TenantDetailsViewModel _:
                    return TenantDetailsCell.Template;
                default:
                    throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
            }
        }
    }
}
