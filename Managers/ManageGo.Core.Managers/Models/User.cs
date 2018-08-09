using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "UserID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "UserFirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "UserLastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "UserEmailAddress")]
        public string EmailAddress { get; set; }
    }
}
