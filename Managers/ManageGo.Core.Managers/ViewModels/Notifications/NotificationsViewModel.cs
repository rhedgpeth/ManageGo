using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class NotificationsViewModel : BaseExpandableCollectionViewModel<NotificationSectionHeaderViewModel>
    {
		public string Subtitle => "Tenants and units awaiting approval";

        public NotificationsViewModel()
        {
			Title = "Pending Approvals";
        }

		public override async Task InitAsync()
        {
            var pendingApprovalsResponse = await PMCService.Instance.GetPendingLeaseApprovals();

            if (pendingApprovalsResponse.Status == ResponseStatus.Data)
            {
                foreach (var pendingApproval in pendingApprovalsResponse.Result)
                {
                    var sectionHeaderViewModel = new NotificationSectionHeaderViewModel();

                    if (pendingApproval.ApprovalType.ToLower() == "tenant")
                    {
                        sectionHeaderViewModel.Title = $"{pendingApproval.TenantFirstName} {pendingApproval.TenantLastName}".Trim();
                    }
                    else
                    {
                        sectionHeaderViewModel.Title = pendingApproval.UnitName;   
                    }

                    sectionHeaderViewModel.Type = pendingApproval.ApprovalType.ToLower() == "tenant" 
                                                        ? NotificationType.Tenant : NotificationType.Unit;

                    sectionHeaderViewModel.Description = pendingApproval.BuildingShortAddress;

                    sectionHeaderViewModel.Children = new List<object>
                                                        {
                                                            new NotificationDetailsViewModel
                                                            {
                                                                LeaseId = pendingApproval.LeaseId,
                                                                Email = pendingApproval.TenantEmailAddress,
                                                                HomePhoneNumber = pendingApproval.TenantHomePhone,
                                                                CellPhoneNumber = pendingApproval.TenantCellPhone
                                                            }
                                                        };

                    Items.Add(sectionHeaderViewModel);
                }
            }
        }
    }
}
