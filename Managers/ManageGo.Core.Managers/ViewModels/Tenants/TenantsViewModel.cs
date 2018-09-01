using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
    public class TenantsViewModel : BaseFilterViewModel<TenantSectionHeaderViewModel>
    {
        public string SearchTerm { get; set; }

        bool _isActive = true;
        public bool IsActive 
        {
            get => _isActive;
            set
            {
                SetPropertyChanged(ref _isActive, value);
                UpdateStatus();
            }
        }

        bool _isInActive;
        public bool IsInActive
        {
            get => _isInActive;
            set
            {
                SetPropertyChanged(ref _isInActive, value);
                UpdateStatus();
            }
        }

        string _status = "Active";
        public string Status
        {
            get => _status;
            set => SetPropertyChanged(ref _status, value);
        }

        ObservableCollection<SelectableItem> _buildings
            = new ObservableCollection<SelectableItem> { new SelectableItem { Id = -1, Description = "All" } };

        public ObservableCollection<SelectableItem> Buildings 
        {
            get => _buildings;
            set => SetPropertyChanged(ref _buildings, value);
        }

        string _selectedBuildingsDescription = "All";
        public string SelectedBuildingsDescription
        {
            get => _selectedBuildingsDescription;
            set => SetPropertyChanged(ref _selectedBuildingsDescription, value);
        }

        List<SelectableItem> _selectedBuildings;
        public List<SelectableItem> SelectedBuildings
        {
            get => _selectedBuildings;
            set
            {
                SetPropertyChanged(ref _selectedBuildings, value);
                ShowUnitsFilterOption = _selectedBuildings?.Count == 1;
            }
        }

        bool _showUnitsFilterOption;
        public bool ShowUnitsFilterOption
        {
            get => _showUnitsFilterOption;
            set => SetPropertyChanged(ref _showUnitsFilterOption, value);
        }

        public TenantsViewModel()
        {
            Title = "Tenants";
        }

        protected override async void LoadFilters()
        {
            var buildings = await BuildingService.Instance.GetBuildings(new PagedRequest { Page = 1, PageSize = 999 });

            if (buildings?.Status == ResponseStatus.Data)
            {
                foreach (var building in buildings.Result)
                {
                    Buildings.Add(new SelectableItem { Id = building.BuildingId, Description = building.BuildingName });
                }
            }
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var tenantsResponse = await TenantService.Instance.GetTenants(GetRequest());

            if (tenantsResponse?.Status == ResponseStatus.Data 
               || tenantsResponse?.Status == ResponseStatus.NoData)
            {
                CanLoadMore = tenantsResponse.Result?.Count == 20;

                var tenantsSectionHeaderViewModels = tenantsResponse.Result?.Select(x => new TenantSectionHeaderViewModel(x));

                LoadItems(refresh, tenantsSectionHeaderViewModels);
            }

            IsBusy = false;
        }

        TenantRequest GetRequest()
        {
            var status = TenantStatus.All;

            if (IsActive != IsInActive)
            {
                if (IsActive)
                {
                    status = TenantStatus.Active;
                }
                else
                {
                    status = TenantStatus.Inactive;
                }
            }

            var request = new TenantRequest
            {
                Page = Page,
                PageSize = 20,
                Search = SearchTerm,
                Status = status
            };

            if (SelectedBuildings?.Count > 0)
            {
                request.Buildings = SelectedBuildings.Select(x => x.Id).ToList();
            }

            return request;
        }

        void UpdateStatus()
        {
            if (IsActive == IsInActive)
            {
                Status = "All";
            }
            else if (IsActive)
            {
                Status = "Active";
            }
            else
            {
                Status = "Inactive";
            }
        }
    }
}
