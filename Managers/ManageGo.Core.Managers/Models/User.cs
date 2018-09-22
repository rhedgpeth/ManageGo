using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmailAddress { get; set; }
    }
}
