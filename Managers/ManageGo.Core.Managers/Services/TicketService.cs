using System;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.Services
{
    public class TicketService : BaseHttpService
    {
        public TicketService() : base(Constants.BaseApiUrl)
        { }
    }
}
