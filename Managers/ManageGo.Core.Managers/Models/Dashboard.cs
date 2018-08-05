using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class Dashboard
    {
        public decimal TotalPaymentsThisWeek { get; set; }
        public decimal TotalPaymentsThisMonth { get; set; }

        [JsonProperty(PropertyName = "NumberOfOpenTickets")]
        public int OpenTicketCount { get; set; }

        [JsonProperty(PropertyName = "NumberOfTicketsWithNoReplay")]
        public int NoReplyTicketCount { get; set; }
    }
}
