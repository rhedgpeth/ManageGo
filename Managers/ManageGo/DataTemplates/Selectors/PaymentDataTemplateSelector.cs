using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class PaymentDataTemplateSelector : DataTemplateSelector
    {
        public PaymentDataTemplateSelector()
        { }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case PaymentSectionHeaderViewModel _:
                    return PaymentSectionHeaderCell.Template;
                case PaymentDetailsViewModel _:
                    return PaymentDetailsCell.Template;
                default:
                    throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
            }
        }
    }
}
