using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class BuildingsViewModel : BaseSearchViewModel
    {
		ObservableCollection<BuildingViewModel> _buildings;
        public ObservableCollection<BuildingViewModel> Buildings 
		{
			get => _buildings;
			set => SetPropertyChanged(ref _buildings, value);
		}

        public BuildingsViewModel()
        {
			Title = "Buildings";
        }

		public override Task InitAsync()
		{
			var buildings = new List<BuildingViewModel>();

			for (int i = 0; i < 10; i++)
			{
				buildings.Add(new BuildingViewModel(new Building
				{
					Name = $"Building {i}",
					UnitCount = (int)RandomNumberBetween(1, 50),
					TenantCount = (int)RandomNumberBetween(1, 100),
					TicketCount = (int)RandomNumberBetween(1, 10)
				}));
			}

			Buildings = new ObservableCollection<BuildingViewModel>(buildings);

			return base.InitAsync();
		}
	}
}
