﻿using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;
using ManageGo.Core.Managers.Models;
using System.Collections.ObjectModel;

namespace ManageGo.Core.Managers.ViewModels
{
    public class BuildingsViewModel : BaseCollectionViewModel<BuildingViewModel>
    {
		ICommand _itemSelectedCommand;
		public ICommand ItemSelectedCommand
		{
			get 
			{
				if (_itemSelectedCommand == null)
				{
					_itemSelectedCommand = new Command<BuildingViewModel>(async (vm) => 
					                                                      await Navigation.PushAsync(new BuildingUnitsViewModel(vm.BuildingId, vm.Name)));
				}

				return _itemSelectedCommand;
			}
		}

        public BuildingsViewModel()
        {
			Title = "Buildings";
        }

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new PagedRequest { Page = Page, PageSize = 20 };

            var buildingsResponse = await BuildingService.Instance.GetBuildings(request);

            if (buildingsResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                CanLoadMore = buildingsResponse.Result.Count == 20;

                var buildingViewModels = buildingsResponse.Result.Select(x => new BuildingViewModel(x));

                LoadItems(refresh, buildingViewModels);
            }

            IsBusy = false;
        }
    }
}
