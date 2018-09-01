using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class BuildingViewModel : BaseNavigationViewModel
    {
		public int BuildingId { get; set; }
		public string Name { get; set; }
		public int UnitCount { get; set; }
        public int TenantCount { get; set; }      
        public int TicketCount { get; set; }

		ICommand _unitsCommand;
		public ICommand UnitsCommand
		{
			get
			{
				if (_unitsCommand == null)
				{
					_unitsCommand = new Command(async () => await Navigation.PushAsync(new BuildingUnitsViewModel(BuildingId, Name)));
				}

				return _unitsCommand;
			}
		}
        
		ICommand _tenantsCommand;
        public ICommand TenantsCommand
        {
            get
            {
				if (_tenantsCommand == null)
                {
					_tenantsCommand = new Command(async () => await Navigation.PushAsync(new TenantsViewModel(BuildingId)));
                }

				return _tenantsCommand;
            }
        }

		ICommand _ticketsCommand;
        public ICommand TicketsCommand
        {
            get
            {
                if (_ticketsCommand == null)
                {
                    _ticketsCommand = new Command(async () => await Navigation.PushAsync(new MaintenanceTicketsViewModel()));
                }

                return _ticketsCommand;
            }
        }
        
        public BuildingViewModel(Building building)
        {
            BuildingId = building.BuildingId;
			Name = building.BuildingName;
			UnitCount = building.UnitCount;
			TenantCount = building.TenantCount;
			TicketCount = building.OpenTicketCount;
        }
    }
}
