using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCalendar;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketsViewModel : BaseFilterViewModel<MaintenanceTicketSectionHeaderViewModel>
    {
        // Buildings
        int? SelectedBuildingId { get; set; }

        List<SelectableItem> _buildings;
        public List<SelectableItem> Buildings
        {
            get => _buildings;
            set => SetPropertyChanged(ref _buildings, value);
        }

        List<SelectableItem> _selectedBuildings;
        public List<SelectableItem> SelectedBuildings
        {
            get => _selectedBuildings;
            set => SetPropertyChanged(ref _selectedBuildings, value);
        }

        string _selectedBuildingsDescription = "All";
        public string SelectedBuildingsDescription
        {
            get => _selectedBuildingsDescription;
            set => SetPropertyChanged(ref _selectedBuildingsDescription, value);
        }

        // Statuses
        List<SelectableItem> _statuses;
        public List<SelectableItem> Statuses
        {
            get => _statuses;
            set => SetPropertyChanged(ref _statuses, value);
        }

        public List<SelectableItem> SelectedStatuses { get; set; }

        string _selectedStatusesDescription = "All";
        public string SelectedStatusesDescription
        {
            get => _selectedStatusesDescription;
            set => SetPropertyChanged(ref _selectedStatusesDescription, value);
        }

        // Priorities
        List<SelectableItem> _priorities;
        public List<SelectableItem> Priorities
        {
            get => _priorities;
            set => SetPropertyChanged(ref _priorities, value);
        }
        public List<SelectableItem> SelectedPriorities { get; set; }

        string _selectedPrioritiesDescription = "All";
        public string SelectedPrioritiesDescription
        {
            get => _selectedPrioritiesDescription;
            set => SetPropertyChanged(ref _selectedPrioritiesDescription, value);
        }

        // Categories
        List<SelectableItem> _categories;
        public List<SelectableItem> Categories
        {
            get => _categories;
            set => SetPropertyChanged(ref _categories, value);
        }

        List<SelectableItem> _selectedCategories;
        public List<SelectableItem> SelectedCategories
        {
            get => _selectedCategories;
            set 
            {
                SetPropertyChanged(ref _selectedCategories, value);

                if (_selectedCategories?.Count > 0)
                {
                    UpdateUsers();
                }
            }
        }

        string _selectedCategoriesDescription = "All";
        public string SelectedCategoriesDescription
        {
            get => _selectedCategoriesDescription;
            set => SetPropertyChanged(ref _selectedCategoriesDescription, value);
        }

        // Tags
        List<SelectableItem> _tags;
        public List<SelectableItem> Tags
        {
            get => _tags;
            set => SetPropertyChanged(ref _tags, value);
        }
        public List<SelectableItem> SelectedTags { get; set; }

        string _selectedTagsDescription = "All";
        public string SelectedTagsDescription
        {
            get => _selectedTagsDescription;
            set => SetPropertyChanged(ref _selectedTagsDescription, value);
        }

        //Users
        List<SelectableItem> _users;
        public List<SelectableItem> Users
        {
            get => _users;
            set => SetPropertyChanged(ref _users, value);
        }
        public List<SelectableItem> SelectedUsers { get; set; }

        string _selectedUsersDescription = "All";
        public string SelectedUsersDescription
        {
            get => _selectedUsersDescription;
            set => SetPropertyChanged(ref _selectedUsersDescription, value);
        }

        public MaintenanceTicketsViewModel()
        {
			Title = "Tickets";
        }

        public MaintenanceTicketsViewModel(int buildId) : this()
        {
            SelectedBuildingId = buildId;
        }

        void UpdateUsers()
        {
            var categoryIds = SelectedCategories.Select(c => c.Id).ToList();

            Users = AppInstance.Users.Where(u => u.Categories
                               .Any(c => categoryIds.Any(cid => cid == c)))?
                               .Select(x => new SelectableItem { Id = x.UserID, Description = x.UserFullName})?
                               .ToList();
            Users.Insert(0, new SelectableItem { Id = -1, Description = "All" });

            SelectedUsers = null;
        }

        protected override async void LoadFilters()
        {
            #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(() =>
             {
                 SelectedDates = new DateRange(DateTime.Now.AddDays(-30).Date, DateTime.Now.Date);

                 Statuses = new List<SelectableItem>
                 {
                    new SelectableItem { Id = -1, Description = "All" },
                    new SelectableItem { Id = 0, Description = "Open" },
                    new SelectableItem { Id = 1, Description = "Closed" },
                    new SelectableItem { Id = 2, Description = "Unread" },
                    new SelectableItem { Id = 3, Description = "Read" },
                    new SelectableItem { Id = 4, Description = "Has Work Order(s)" },
                    new SelectableItem { Id = 5, Description = "Past Due" }
                 };

                 Priorities = new List<SelectableItem>
                 {
                    new SelectableItem { Id = -1, Description = "All" },
                    new SelectableItem { Id = 0, Description = "Low" },
                    new SelectableItem { Id = 1, Description = "Medium" },
                    new SelectableItem { Id = 2, Description = "High" }
                 };

                 Categories = AppInstance.Maintenance
                                         .Settings?
                                         .Categories?
                                         .Select(x => new SelectableItem { Id = x.CategoryId, Description = x.CategoryName })
                                         .OrderBy(y => y.Description)
                                         .ToList();
                 Categories.Insert(0, new SelectableItem { Id = -1, Description = "All" });

                 Tags = AppInstance.Maintenance
                                   .Settings?
                                   .Tags?
                                   .Select(x => new SelectableItem { Id = x.TagId, Description = x.TagName })
                                   .OrderBy(y => y.Description)
                                   .ToList();
                 Tags.Insert(0, new SelectableItem { Id = -1, Description = "All" });

                 Users = AppInstance.Users?
                                   .Select(x => new SelectableItem { Id = x.UserID, Description = x.UserFullName })?
                                   .OrderBy(y => y.Description)?
                                   .ToList();
                 Users.Insert(0, new SelectableItem { Id = -1, Description = "All" });
             });
            #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            var buildings = await BuildingService.Instance.GetBuildings(new PagedRequest { Page = 1, PageSize = 999 });

            if (buildings?.Status == ResponseStatus.Data)
            {
                var items = buildings.Result.Select(b => new SelectableItem
                { Id = b.BuildingId, Description = b.BuildingName }).OrderBy(x => x.Description).ToList();

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
                            SelectedBuildingId = null;
                        }
                    }

                    Buildings = items;
                }
            }
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var ticketsResponse = await MaintenanceService.Instance.GetTickets(GetRequest());

            if (ticketsResponse?.Status == ResponseStatus.Data ||
                ticketsResponse?.Status == ResponseStatus.NoData)
            {
                CanLoadMore = ticketsResponse.Result.Count == 20;

                var sectionHeaders = new List<MaintenanceTicketSectionHeaderViewModel>();

                foreach (var ticket in ticketsResponse.Result)
                {
                    sectionHeaders.Add(new MaintenanceTicketSectionHeaderViewModel(ticket));
                }

                LoadItems(refresh, sectionHeaders);
            }

            IsBusy = false;
        }

        MaintenanceTicketsRequest GetRequest()
        {
            int filterCount = 0;

            var request = new MaintenanceTicketsRequest
            {
                DateFrom = SelectedDates.StartDate,
                DateTo = SelectedDates.EndDate,
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                filterCount++;
            }

            if (SelectedBuildingId.HasValue)
            {
                filterCount++;
                request.Buildings = new List<int> { SelectedBuildingId.Value };
            }
            else if (SelectedBuildings?.Count > 0)
            {
                filterCount++;
                request.Buildings = SelectedBuildings.Select(x => x.Id).ToList();
            }

            if (SelectedPriorities?.Count > 0 && SelectedPriorities?.Count < Priorities.Count)
            {
                filterCount++;
                request.Priorites = SelectedPriorities.Select(x => x.Id).ToList();
            }

            if (SelectedStatuses?.Count > 0 && SelectedStatuses?.Count < Statuses.Count)
            {
                filterCount++;
                request.Statuses = SelectedPriorities.Select(x => x.Id).ToList();
            }

            if (SelectedCategories?.Count > 0 && SelectedCategories?.Count < Categories.Count)
            {
                filterCount++;
                request.Priorites = SelectedCategories.Select(x => x.Id).ToList();
            }

            if (SelectedTags?.Count > 0 && SelectedTags?.Count < Tags.Count)
            {
                filterCount++;
                request.Priorites = SelectedTags.Select(x => x.Id).ToList();
            }

            FilterCount = filterCount > 0 ? filterCount : (int?)null;

            return request;
        }
    }
}
