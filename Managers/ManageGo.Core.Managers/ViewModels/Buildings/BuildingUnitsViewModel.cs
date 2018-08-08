using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class BuildingUnitsViewModel : BaseSearchViewModel<BuildingUnitViewModel> 
    {
		int BuildingId { get; set; }

		string _buildingName;
        public string BuildingName
        {
            get => _buildingName;
            set => SetPropertyChanged(ref _buildingName, value);
        }

		ICommand _tenantsSelectedCommand;
        public ICommand TenantsSelectedCommand
        {
            get
            {
				if (_tenantsSelectedCommand == null)
                {
					_tenantsSelectedCommand = new Command(async () => await Navigation.PushAsync(new TenantsViewModel()));
                }

				return _tenantsSelectedCommand;
            }
        }

        public BuildingUnitsViewModel(int buildingId, string buildingName)
        {
			Title = "Units";
            
			BuildingId = buildingId;
			BuildingName = buildingName;
        }
        
		public override async Task InitAsync()
		{
			var units = await BuildingService.Instance.GetUnits(BuildingId);

            Items = new ObservableCollection<BuildingUnitViewModel>(units?.Select(u => new BuildingUnitViewModel(u)).ToList());
		}      
	}
}
