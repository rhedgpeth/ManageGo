using System.Linq;

namespace ManageGo.Core.ViewModels
{
	public abstract class BaseExpandableCollectionViewModel<T> : BaseCollectionViewModel<object> where T : BaseCollectionSectionViewModel
    {
		public void OnSectionHeaderSelected(T section)
        {         
			if (section.IsExpanded)
			{
				RemoveExpandedItems(section);
			}
			else
			{
				for (int i = _items.IndexOf(section) + 1, j = 0; j < section.Children.Count; i++, j++)
				{
					_items.Insert(i, section.Children[j]);
				}

				if (_items.FirstOrDefault(s => s != section && s.GetType() == typeof(T)
															&& ((T)s).IsExpanded) is T expandedSection)
				{
					RemoveExpandedItems(expandedSection);
					expandedSection.IsExpanded = false;
				}
			}

            section.IsExpanded = !section.IsExpanded;
        }

		void RemoveExpandedItems(T section)
		{
			foreach (var child in section.Children)
            {
                _items.Remove(child);
            }
		}
    }
}
