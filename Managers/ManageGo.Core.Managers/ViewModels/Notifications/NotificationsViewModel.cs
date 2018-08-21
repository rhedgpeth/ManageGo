using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class NotificationsViewModel : BaseExpandableCollectionViewModel<NotificationSectionHeaderViewModel>
    {
		public string Subtitle => "Tenants and units awaiting approval";

        public NotificationsViewModel()
        {
			Title = "Pending Approvals";

            var messageService = ServiceContainer.Resolve<IMessageService>();

            messageService?.Subscribe<NotificationDetailsViewModel>(this, "RefreshList", ReceivedUpdateRequest);
        }

        async void ReceivedUpdateRequest(NotificationDetailsViewModel details) => await LoadAsync(true);

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            var pendingApprovalsResponse = await PMCService.Instance.GetPendingLeaseApprovals();

            if (pendingApprovalsResponse.Status == ResponseStatus.Data)
            {
                var items = new List<NotificationSectionHeaderViewModel>();

                foreach (var pendingApproval in pendingApprovalsResponse.Result)
                {
                    var sectionHeaderViewModel = new NotificationSectionHeaderViewModel();

                    if (pendingApproval.ApprovalType.ToLower() == "tenant")
                    {
                        sectionHeaderViewModel.Title = $"{pendingApproval.Tenant.TenantFirstName} {pendingApproval.Tenant.TenantLastName}".Trim();
                    }
                    else
                    {
                        sectionHeaderViewModel.Title = pendingApproval.Unit.UnitName;
                    }

                    sectionHeaderViewModel.Type = pendingApproval.ApprovalType.ToLower() == "tenant"
                                                        ? NotificationType.Tenant : NotificationType.Unit;

                    sectionHeaderViewModel.Description = pendingApproval.Building.BuildingShortAddress;

                    sectionHeaderViewModel.Children = new List<object>
                                                        {
                                                            new NotificationDetailsViewModel
                                                            {
                                                                LeaseId = pendingApproval.LeaseId,
                                                                LeaseName = sectionHeaderViewModel.Title,
                                                                Email = pendingApproval.Tenant.TenantEmailAddress,
                                                                HomePhoneNumber = pendingApproval.Tenant.TenantHomePhone,
                                                                CellPhoneNumber = pendingApproval.Tenant.TenantCellPhone
                                                            }
                                                        };



                    items.Add(sectionHeaderViewModel);
                }

                if (items != null)
                {
                    Items = new ObservableCollection<object>(items);
                }
            }

            IsBusy = false;
        }
    }
}
