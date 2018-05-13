using System;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class NotificationSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string Title { get; set; }

		public string Description { get; set; }

		public NotificationType Type { get; set; }

        public NotificationSectionHeaderViewModel()
        { }
    }
}
