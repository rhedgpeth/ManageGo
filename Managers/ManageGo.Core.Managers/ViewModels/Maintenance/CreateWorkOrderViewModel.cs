using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CreateWorkOrderViewModel : BaseEditViewModel
    {
        MaintenanceTicketWorkOrder WorkOrder { get; set; }

        string _summary;
        [Required(ErrorMessage = "Summary is required.")]
        public string Summary
        {
            get => _summary;
            set => SetPropertyChanged(ref _summary, value);
        }

        string _details;
        [Required(ErrorMessage = "Details are required.")]
        public string Details
        {
            get => _details;
            set => SetPropertyChanged(ref _details, value);
        }

        List<SelectableItem> _users;
        public List<SelectableItem> Users
        {
            get => _users;
            set => SetPropertyChanged(ref _users, value);
        }

        ObservableCollection<SelectableItem> _selectedUsers;
        public ObservableCollection<SelectableItem> SelectedUsers
        {
            get => _selectedUsers;
            set => SetPropertyChanged(ref _selectedUsers, value);
        }

        List<SelectableItem> _externalContacts;
        public List<SelectableItem> ExternalContacts
        {
            get => _externalContacts;
            set => SetPropertyChanged(ref _externalContacts, value);
        }

        ObservableCollection<SelectableItem> _selectedExternalContacts;
        public ObservableCollection<SelectableItem> SelectedExternalContacts
        {
            get => _selectedExternalContacts;
            set => SetPropertyChanged(ref _selectedExternalContacts, value);
        }

        string _sendToEmail;
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email address.")]
        public string SendToEmail
        {
            get => _sendToEmail;
            set => SetPropertyChanged(ref _sendToEmail, value);
        }

        public CreateWorkOrderViewModel(int ticketId)
        {
            WorkOrder = new MaintenanceTicketWorkOrder { TicketId = ticketId };
        }

        public CreateWorkOrderViewModel(MaintenanceTicketWorkOrder workOrder)
        {
            WorkOrder = workOrder;
        }

        public override Task InitAsync()
        {
            Users = AppInstance.Users.Select(u => new SelectableItem { Id = u.UserID, Description = u.UserFullName }).ToList();

            ExternalContacts = AppInstance.Maintenance.Settings.ExternalContacts
                                       .Select(ec => new SelectableItem { Id = ec.Id, Description = ec.Name }).ToList();

            // TODO: Hook up previously selected users and contacts

            return base.InitAsync();
        }

        protected override async Task Save()
		{
            if (ValidateProperties())
            {
                var workOrderResponse = await MaintenanceService.Instance.SaveWorkOrder(GetWorkOrder());

                if (workOrderResponse.Status == Enumerations.ResponseStatus.Data ||
                   workOrderResponse.Status == Enumerations.ResponseStatus.ActionSuccessful)
                {
                    await Dismiss();
                }
            }
		}

        MaintenanceTicketWorkOrder GetWorkOrder()
        {
            WorkOrder.Summary = Summary;
            WorkOrder.Details = Details;
            WorkOrder.SendToUsers = SelectedUsers?.Select(x => x.Id)?.ToList();
            WorkOrder.SendToExternalContacts = SelectedExternalContacts?.Select(x => x.Id)?.ToList();

            return WorkOrder;
        }
	}
}
