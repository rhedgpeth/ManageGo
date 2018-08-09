using System.Collections.Generic;
using System.Linq;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class BuildingUnitViewModel : BaseNavigationViewModel
    {
		string _number;
        public string Number
        {
            get => _number;
            set => SetPropertyChanged(ref _number, value);
        }

        List<string> _tenantNames;
        public List<string> TenantNames
        {
            get => _tenantNames;
            set => SetPropertyChanged(ref _tenantNames, value);
        }
      
        public BuildingUnitViewModel(Unit unit)
        {
			Number = unit.Number;
            TenantNames = unit.Tenants.Select(t => $"{t.FirstName} {t.LastName}").ToList();
        }
    }
}
