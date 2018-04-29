using System;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.DataTemplates.ViewCells;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.Selectors
{
	public class TransactionDataTemplateSelector : DataTemplateSelector
	{
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			switch (item)
			{
				case TransactionSectionHeaderViewModel _:
					return TransactionSectionHeaderCell.Template;
				case TenantDetailsViewModel _:
					return TransactionDetailsCell.Template;
				default:
					throw new ArgumentException($"Unknown item type '{item?.GetType()}'", nameof(item));
			}
		}
	}
}
