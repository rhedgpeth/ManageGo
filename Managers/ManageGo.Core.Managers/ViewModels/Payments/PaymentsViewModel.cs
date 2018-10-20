using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CustomCalendar;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.Managers.Enumerations;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentsViewModel : BaseFilterViewModel<PaymentSectionHeaderViewModel>
    {
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

                if (_selectedUnits?.Count == 1)
                {
                    ShowTenantsFilterOption = true;
                    LoadTenants(_selectedUnits[0].Id);
                }
                else
                {
                    ShowTenantsFilterOption = false;
                }
            }
        }

        string _selectedUnitsDescription = "All";
        public string SelectedUnitsDescription
        {
            get => _selectedUnitsDescription;
            set => SetPropertyChanged(ref _selectedUnitsDescription, value);
        }

        bool _showTenantsFilterOption;
        public bool ShowTenantsFilterOption
        {
            get => _showTenantsFilterOption;
            set => SetPropertyChanged(ref _showTenantsFilterOption, value);
        }

        ObservableCollection<SelectableItem> _tenants;
        public ObservableCollection<SelectableItem> Tenants
        {
            get => _tenants;
            set => SetPropertyChanged(ref _tenants, value);
        }

        List<SelectableItem> _selectedTenants;
        public List<SelectableItem> SelectedTenants
        {
            get => _selectedTenants;
            set
            {
                SetPropertyChanged(ref _selectedTenants, value);
            }
        }

        string _selectedTenantsDescription = "All";
        public string SelectedTenantsDescription
        {
            get => _selectedTenantsDescription;
            set => SetPropertyChanged(ref _selectedTenantsDescription, value);
        }

        ObservableCollection<SelectableItem> _statuses;
        public ObservableCollection<SelectableItem> Statuses
        {
            get => _statuses;
            set => SetPropertyChanged(ref _statuses, value);
        }

        List<SelectableItem> _selectedStatuses;
        public List<SelectableItem> SelectedStatuses
        {
            get => _selectedStatuses;
            set
            {
                SetPropertyChanged(ref _selectedStatuses, value);
            }
        }

        string _selectedStatusesDescription = "All";
        public string SelectedStatusesDescription
        {
            get => _selectedStatusesDescription;
            set => SetPropertyChanged(ref _selectedStatusesDescription, value);
        }

        int _fromAmount = 0;
        public int FromAmount
        {
            get => _fromAmount;
            set
            {
                SetPropertyChanged(ref _fromAmount, value);
                SetPropertyChanged(nameof(AmountDescription));
            }
        }

        int _toAmount = 10000;
        public int ToAmount
        {
            get => _toAmount;
            set
            {
                SetPropertyChanged(ref _toAmount, value);
                SetPropertyChanged(nameof(AmountDescription));
            }
        }

        public string AmountDescription
        {
            get
            {
                return $"{FromAmount.ToString("C0")} - {ToAmount.ToString("C0")}";
            }
        }

        public PaymentsViewModel()
        {
            Title = "Payments";
        }

        protected override async void LoadFilters()
        {
            SelectedDates = new DateRange(DateTime.Now.AddDays(-30), DateTime.Now);

            var statuses = new List<SelectableItem>
            {
                new SelectableItem { Id = -1, Description = "All" },
                new SelectableItem { Id = 0, Description = "Passed" },
                new SelectableItem { Id = 1, Description = "Submitted" },
                new SelectableItem { Id = 2, Description = "Reversed" },
                new SelectableItem { Id = 3, Description = "Refunded" },
                new SelectableItem { Id = 4, Description = "Refund Pending" },
            };

            Statuses = new ObservableCollection<SelectableItem>(statuses);

            await LoadBuildings();
        }

        async Task LoadBuildings()
        {
            var buildings = await BuildingService.Instance.GetBuildings(new PagedRequest { Page = 1, PageSize = 999 });

            if (buildings?.Status == ResponseStatus.Data)
            {
                var items = buildings.Result.Select(b => new SelectableItem
                { Id = b.BuildingId, Description = b.BuildingName }).ToList();

                if (items != null)
                {
                    items.Insert(0, new SelectableItem { Id = -1, Description = "All" });
                    Buildings = new ObservableCollection<SelectableItem>(items);
                }
            }
        }

        List<Unit> AllUnits { get; set; }

        async void LoadUnits(int buildingId)
        {
            var unitsResponse = await BuildingService.Instance.GetBuildingDetails(new Building { PropertyId = buildingId });

            if (unitsResponse?.Status == ResponseStatus.Data)
            {
                AllUnits = unitsResponse.Result?.Units;

                var units = AllUnits?.Select(u => new SelectableItem
                { Id = u.UnitId, Description = u.UnitName }).ToList();

                if (units?.Count > 0)
                {
                    units.Insert(0, new SelectableItem { Id = -1, Description = "All" });
                    Units = new ObservableCollection<SelectableItem>(units);
                }
            }
        }

        void LoadTenants(int unitId)
        {
            var tenants = AllUnits.SingleOrDefault(u => u.UnitId == unitId)?
                                  .Tenants?
                                  .Select(t => new SelectableItem
                                  {
                                      Id = t.TenantId,
                                      Description = $"{t.TenantFirstName} {t.TenantLastName}"
                                  }).ToList();

            if (tenants?.Count > 0)
            {
                Tenants = new ObservableCollection<SelectableItem>(tenants);
            }
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var paymentsResponse = await FinanceService.Instance.GetPayments(GetRequest()).ConfigureAwait(false);

            if (paymentsResponse?.Status == ResponseStatus.Data ||
                paymentsResponse?.Status == ResponseStatus.NoData)
            {
                CanLoadMore = paymentsResponse.Result.Count == 20;

                var sectionHeaders = new List<PaymentSectionHeaderViewModel>();

                foreach (var payment in paymentsResponse.Result)
                {
                    sectionHeaders.Add(new PaymentSectionHeaderViewModel(payment));
                }

                LoadItems(refresh, sectionHeaders);
            }

            IsBusy = false;
        }

        PaymentRequest GetRequest()
        {
            int filterCount = 0;

            var request = new PaymentRequest
            {
                DateFrom = SelectedDates.StartDate,
                DateTo = SelectedDates.EndDate.Value,
                AmountFrom = FromAmount,
                AmountTo = ToAmount,
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                filterCount++;
            }

            if (FromAmount > 0 || ToAmount < 10000)
            {
                filterCount++;
            }

            if (SelectedBuildings?.Count > 0)
            {
                filterCount++;
                request.Buildings = SelectedBuildings.Select(x => x.Id).ToList();
            }

            if (SelectedBuildings?.Count == 1 && SelectedUnits?.Count > 0)
            {
                filterCount++;
                request.Units = SelectedUnits.Select(x => x.Id).ToList();
            }

            if (SelectedUnits?.Count == 1 && SelectedTenants?.Count > 0)
            {
                filterCount++;
                request.Tenants = SelectedTenants.Select(x => x.Id).ToList();
            }

            if (SelectedStatuses?.Count > 0)
            {
                filterCount++;
            }

            FilterCount = filterCount > 0 ? filterCount : (int?)null;

            return request;
        }
	}
}
