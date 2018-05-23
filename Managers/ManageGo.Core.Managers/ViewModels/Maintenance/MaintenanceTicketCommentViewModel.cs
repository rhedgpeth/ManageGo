using System;
namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketCommentViewModel
    {
		public string FirstColor { get; set; }

		public string SecondColor { get; set; }

		public string Name { get; set; }

        public string CreateDateTimeDescription { get; set; }

        public string Comment { get; set; }

		public bool IsAccessGranted { get; set; }

		public string AccessGrantedDateTime { get; set; }

		public string AccessGrantedTimeSpan { get; set; }

		public string AccessDescription { get; set; }

		public bool HasImage { get; set; }

		public string ImageName { get; set; }

        public MaintenanceTicketCommentViewModel()
        { }
    }
}
