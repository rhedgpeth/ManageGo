namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceUserSettings
    {
        public MaintenanceCategory[] Categories { get; set; }
        public MaintenanceTag[] Tags { get; set; }
        public MaintenanceExternalContact[] ExternalContacts { get; set; }
        public MaintenanceCloseAndNotifyTemplate[] CloseAndNotifyTemplates { get; set; }
    }
}
