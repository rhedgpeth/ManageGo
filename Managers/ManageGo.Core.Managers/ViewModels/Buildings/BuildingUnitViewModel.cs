﻿using System.Collections.Generic;
using System.Linq;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class BuildingUnitViewModel : BaseNavigationViewModel
    {
        public int UnitId { get; set; }

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
            UnitId = unit.UnitId;
			Number = unit.UnitName;
            TenantNames = unit.Tenants.Select(t => $"{t.TenantFirstName} {t.TenantLastName}").ToList();
        }
    }
}
