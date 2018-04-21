using System;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CreateEventViewModel : BaseEditViewModel
    {
        public CreateEventViewModel()
        { }

		protected override Task Save()
        {
            // TODO: Save thangs

            return Dismiss();
        }
    }
}
