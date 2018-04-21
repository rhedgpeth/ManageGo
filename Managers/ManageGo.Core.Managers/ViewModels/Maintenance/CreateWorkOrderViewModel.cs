using System;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CreateWorkOrderViewModel : BaseEditViewModel
    {
        public CreateWorkOrderViewModel()
        { }

		protected override Task Save()
		{
			// TODO: Save thangs

			return Dismiss();
		}
	}
}
