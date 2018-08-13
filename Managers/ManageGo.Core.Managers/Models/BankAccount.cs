using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class BankAccount
    {
        [JsonProperty(PropertyName = "BankAccountID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "BankAccountName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "BankAccountNumber")]
        public string Number { get; set; }
    }
}
