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

        ObservableCollection<SelectableItem> _buildings;
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

                if (_selectedBuildings?.Count == 1)
                {
                    ShowUnitsFilterOption = true;
                    LoadUnits(_selectedBuildings[0].Id);
                }
                else
                {
                    ShowUnitsFilterOption = false;
                }
            }
        }

        bool _showUnitsFilterOption;
        public bool ShowUnitsFilterOption
        {
            get => _showUnitsFilterOption;
            set => SetPropertyChanged(ref _showUnitsFilterOption, value);
        }

        ObservableCollection<SelectableItem> _units;
        public ObservableCollection<SelectableItem> Units
        {
            get => _units;
            set => SetPropertyChanged(ref _units, value);
        }

        List<SelectableItem> _selectedUnits;
        public List<SelectableItem> SelectedUnits
        {
            get => _selectedUnits;
            set
            {
                SetPropertyChanged(ref _selectedUnits, value);
            }
        }

        string _selectedUnitsDescription = "All";
        public string SelectedUnitsDescription
        {
            get => _selectedUnitsDescription;
            set => SetPropertyChanged(ref _selectedUnitsDescription, value);
        }

        int? SelectedBuildingId { get; set; }
        int? SelectedUnitId { get; set; }

        public TenantsViewModel()
        {
            Title = "Tenants";
        }

        public TenantsViewModel(int buildingId)
        {
            SelectedBuildingId = buildingId;
        }

        public TenantsViewModel(int buildingId, int unitId)
        {
            SelectedBuildingId = buildingId;
            SelectedUnitId = unitId;
        }

        protected override async void LoadFilters()
        {
            var buildings = await BuildingService.Instance.GetBuildings(new PagedRequest { Page = 1, PageSize = 999 });

            if (buildings?.Status == ResponseStatus.Data)
            {
                var items = buildings.Result.Select(b =>new SelectableItem
                                                            { Id = b.BuildingId, Description = b.BuildingName }).ToList();

                if (items != null)
                {
                    items.Insert(0, new SelectableItem { Id = -1, Description = "All" });

                    if (SelectedBuildingId.HasValue)
                    {
                        var item = items.SingleOrDefault(i => i.Id == SelectedBuildingId.Value);

                        if (item != null)
                        {
                            item.IsSelected = true;

                            SelectedBuildings = new List<SelectableItem> { item };

                            LoadUnits(SelectedBuildingId.Value);
                        }
                    }

                    Buildings = new ObservableCollection<SelectableItem>(items);
                }
            }
        }

        async void LoadUnits(int buildingId)
        {
            var unitsResponse = await BuildingService.Instance.GetBuildingDetails(new Building { PropertyId = buildingId });

            if (unitsResponse?.Status == ResponseStatus.Data)
            {
                var items = unitsResponse.Result?.Units?.Select(u => new SelectableItem
                    { Id = u.UnitId, Description = u.UnitName }).ToList();

                items.Insert(0, new SelectableItem { Id = -1, Description = "All" });

                if (SelectedUnitId.HasValue)
                {
                    var item = items.SingleOrDefault(i => i.Id == SelectedUnitId.Value);

                    if (item != null)
                    {
                        item.IsSelected = true;

                        SelectedUnits = new List<SelectableItem> { item };
                    }
                }

                Units = new ObservableCollection<SelectableItem>(items);
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
                status = IsActive ? TenantStatus.Active : TenantStatus.Inactive;
            }

            var request = new TenantRequest
            {
                Page = Page,
                PageSize = 20,
                Search = SearchTerm,
                Status = status
            };

            if (SelectedBuildingId.HasValue)
            {
                request.Buildings = new List<int> { SelectedBuildingId.Value };
            }
            else if (SelectedBuildings?.Count > 0)
            {
                request.Buildings = SelectedBuildings.Select(x => x.Id).ToList();
            }

            if (SelectedUnitId.HasValue)
            {
                request.Units = new List<int> { SelectedUnitId.Value };
            }
            else if (SelectedUnits?.Count > 0)
            {
                request.Units = SelectedUnits.Select(x => x.Id).ToList();
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
