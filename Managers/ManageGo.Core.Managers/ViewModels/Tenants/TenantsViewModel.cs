using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TenantsViewModel : BaseExpandableCollectionViewModel<TenantSectionHeaderViewModel>
    {
        public TenantsViewModel()
        {
			Title = "Tenants";
        }

		public override async Task InitAsync()
        {
            var items = new List<object>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new TenantSectionHeaderViewModel
                {
                    Name = $"Person {i}",
                    Address = $"1234 Main St. Apt. #{i}",
                    Children = new List<object>
                                    {
                                        new TenantDetailsViewModel
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
