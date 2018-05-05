using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class BuildingUnitsViewModel : BaseSearchViewModel 
    {
		int BuildingId { get; set; }

		string _buildingName;
        public string BuildingName
        {
            get => _buildingName;
            set => SetPropertyChanged(ref _buildingName, value);
        }

		List<BuildingUnitViewModel> _units;
		public List<BuildingUnitViewModel> Units
		{
			get => _units;
			set => SetPropertyChanged(ref _units, value);
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

			Units = units?.Select(u => new BuildingUnitViewModel(u)).ToList();
		}      
	}
}
