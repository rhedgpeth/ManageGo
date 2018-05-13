using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class NotificationsViewModel : BaseExpandableCollectionViewModel<NotificationSectionHeaderViewModel>
    {
		public string Subtitle => "Tenants and units awaiting approval";

        public NotificationsViewModel()
        {
			Title = "Notifications";
        }

		public override async Task InitAsync()
        {
            var items = new List<object>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new NotificationSectionHeaderViewModel 
                              { 
					                Title = $"Notification {i}",
					                Type = i % 2 ==0 ? NotificationType.Tenant : NotificationType.Unit,
					                Description = i % 2 == 0 ? $"12{i} Main St." : $"Building Manager {i}",
                                    Children = new List<object> 
                                    { 
                                        new NotificationDetailsViewModel 
                                        { 
							                Email = $"person{i}@gmail.com",
                                            HomePhoneNumber = $"(417)844-555{i}",
                                            CellPhoneNumber = $"(417)844-55{i}1"
                                        }
                                    }  
                                });
            }

            Items = new ObservableCollection<object>(items);
        }  
    }
}
