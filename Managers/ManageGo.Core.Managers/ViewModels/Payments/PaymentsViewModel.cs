﻿using System;
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
			await Task.Delay(250).ConfigureAwait(false);
                     
			var taskItems = await Task.Run(() =>
			{
				var items = new List<object>();

				for (int i = 0; i < 10; i++)
				{
					items.Add(new PaymentSectionHeaderViewModel
					{
						Amount = string.Format("${0:#.00}", Convert.ToDecimal(RandomNumberBetween(1, 10000) / 100)),
						PaymentDateTime = DateTime.Now.AddDays(-10).AddDays(i).ToShortDateString() + " 8:00 AM",
						Name = $"Person {i}",
						Address = $"1234 Main St. Apt. #{i}",
						Children = new List<object>
									{
										new PaymentDetailsViewModel
										{
											Description = $"This is a description for payment {i}."
										}
									}
					});
				}

				return items;
			});

			Items = new ObservableCollection<object>(taskItems);
		}      
	}
}
