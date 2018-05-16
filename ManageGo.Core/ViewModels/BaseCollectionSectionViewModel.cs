using System;
using System.Collections;
using System.Collections.Generic;

namespace ManageGo.Core.ViewModels
{
	public abstract class BaseCollectionSectionViewModel : BaseNotify
	{
		bool _isExpanded;
		public bool IsExpanded
		{
			get => _isExpanded;
			set 
			{
				SetPropertyChanged(ref _isExpanded, value);
				SetPropertyChanged(nameof(IsCollapsed));
			}
		}
        
		public bool IsCollapsed
        {
			get
			{
				return !_isExpanded;
			}
        }

		IList<object> _children;
		public IList<object> Children
		{
			get => _children;
			set => _children = value;
		}
    }
}
