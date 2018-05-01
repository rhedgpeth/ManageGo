using System;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class BuildingUnitsViewModel : BaseSearchViewModel 
    {
		public string BuildingName { get; set; }

        public BuildingUnitsViewModel(int buildingId, string buildingName)
        {
			Title = "Units";

			BuildingName = buildingName;

			// TODO: Use BuildingId to retrieve the building units 
			//       (call should be cached)
        }
    }
}
