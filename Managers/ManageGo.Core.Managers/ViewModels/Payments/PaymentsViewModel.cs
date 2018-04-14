using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentsViewModel : BaseExpandableCollectionViewModel<PaymentSectionHeaderViewModel>
    {      
        public PaymentsViewModel()
        {
            Title = "Payments";
        }

		public override async Task InitAsync()
		{
			var items = new List<object>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new PaymentSectionHeaderViewModel 
				              { 
					                Title = $"Payment {i}", 
					                Children = new List<object> 
					                { 
						                new PaymentDetailsViewModel 
						                { 
						                    Description = $"This is a description for payment {i}." 
						                }
					                }  
				                });
            }

			Items = new ObservableCollection<object>(items);
		}
	}
}
