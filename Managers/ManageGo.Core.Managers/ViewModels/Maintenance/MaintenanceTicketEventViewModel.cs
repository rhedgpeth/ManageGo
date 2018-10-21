using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketEventViewModel : BaseEditViewModel
    {
        MaintenanceTicketEvent Event { get; set; }

        string _subject;
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject
        {
            get => _subject;
            set => SetPropertyChanged(ref _subject, value);
        }

        string _comments;
        [Required(ErrorMessage = "Comments are required.")]
        public string Comments
        {
            get => _comments;
            set => SetPropertyChanged(ref _comments, value);
        }

        List<SelectableItem> _users;
        public List<SelectableItem> Users
        {
            get => _users;
            set => SetPropertyChanged(ref _users, value);
        }

        ObservableCollection<SelectableItem> _selectedUsers = new ObservableCollection<SelectableItem>();
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

        ObservableCollection<SelectableItem> _selectedExternalContacts = new ObservableCollection<SelectableItem>();
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

        bool _showDateTime;
        public bool ShowDateTime
		{
			get => _showDateTime;
			set => SetPropertyChanged(ref _showDateTime, value);
		}

		ICommand _toggleDateTimeCommand;
		public ICommand ToggleDateTimeCommand
		{
			get
			{
				if (_toggleDateTimeCommand == null)
				{
					_toggleDateTimeCommand = new Command(ToggleDateTime);
				}

				return _toggleDateTimeCommand;
			}
		}

        public MaintenanceTicketEventViewModel(int ticketId)
        {
            Event = new MaintenanceTicketEvent { TicketId = ticketId };
        }

        public MaintenanceTicketEventViewModel(MaintenanceTicketEvent evt) => LoadEvent(evt);

        void LoadEvent(MaintenanceTicketEvent evt)
        {
            Event = evt;

            Subject = evt.Title;
            Comments = evt.Note;
        }

        public override Task InitAsync()
        {
            // Users
            var users = AppInstance.Users.Select(u => new SelectableItem { Id = u.UserID, Description = u.UserFullName }).ToList();

            if (Event?.SendToUsers?.Count > 0)
            {
                var selectedUsers = users.Where(u => Event.SendToUsers.Any(x => x.UserID == u.Id)).ToList();

                foreach (var selectedUser in selectedUsers)
                {
                    selectedUser.IsSelected = true;
                    SelectedUsers.Add(selectedUser);
                }
            }

            Users = users;

            // External Contacts
            var externalContacts = AppInstance.Maintenance.Settings.ExternalContacts
                                       .Select(ec => new SelectableItem { Id = ec.Id, Description = ec.Name }).ToList();

            if (Event?.SendToExternalContacts?.Count > 0)
            {
                var selectedExternalContacts = externalContacts.Where(u => Event.SendToExternalContacts.Any(x => x.Id == u.Id)).ToList();

                foreach (var selectedExternalContact in selectedExternalContacts)
                {
                    selectedExternalContact.IsSelected = true;
                    SelectedExternalContacts.Add(selectedExternalContact);
                }
            }

            ExternalContacts = externalContacts;

            return base.InitAsync();
        }

        protected override async Task Save()
        {
            if (ValidateProperties())
            {
                var eventResponse = await MaintenanceService.Instance.SaveEvent(GetEvent());

                if (eventResponse.Status == Enumerations.ResponseStatus.Data ||
                    eventResponse.Status == Enumerations.ResponseStatus.ActionSuccessful)
                {
                    await Dismiss();
                }
            }
        }

        MaintenanceTicketEvent GetEvent()
        {
            Event.Title = Subject;
            Event.Note = Comments;

            // TODO: The rest of the event stuffs

            return Event;
        }

        void ToggleDateTime() => ShowDateTime = !ShowDateTime;
    }
}
