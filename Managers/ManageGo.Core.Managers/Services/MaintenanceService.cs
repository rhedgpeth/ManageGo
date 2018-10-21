using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class MaintenanceService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<MaintenanceService> lazy = new Lazy<MaintenanceService>(() => new MaintenanceService());
        public static MaintenanceService Instance { get { return lazy.Value; } }

        MaintenanceService() { }

        public Task<BaseResponse<MaintenanceUserSettings>> GetUserSettings()
            => PostAsync<BaseResponse<MaintenanceUserSettings>>("maintenanceobjects", default(CancellationToken), AddAccessToken); 

        public Task<BaseResponse<List<MaintenanceTicket>>> GetTickets(MaintenanceTicketsRequest request)
        {
            return PostAsync<BaseResponse<List<MaintenanceTicket>>, 
                MaintenanceTicketsRequest>("tickets", request, default(CancellationToken), AddAccessToken);
        }

        public Task<BaseResponse<MaintenanceTicket>> GetTicketDetails(MaintenanceTicket ticket)
            => PostAsync<BaseResponse<MaintenanceTicket>, MaintenanceTicket>("ticketdetails", 
                                                                             ticket, 
                                                                             default(CancellationToken), 
                                                                             AddAccessToken);

        public Task<BaseResponse<List<MaintenanceTicketEvent>>> GetEvents(DateRangeRequest request)
            => PostAsync<BaseResponse<List<MaintenanceTicketEvent>>, DateRangeRequest>("eventlist", 
                                                                                       request, 
                                                                                       default(CancellationToken), 
                                                                                       AddAccessToken);

        public Task<BaseResponse<MaintenanceTicketEventDates>> GetEventDates(DateRangeRequest request)
            => PostAsync<BaseResponse<MaintenanceTicketEventDates>, DateRangeRequest>("eventslistdates",
                                                                        request,
                                                                        default(CancellationToken),
                                                                        AddAccessToken);

        public Task<BaseResponse<MaintenanceTicketWorkOrder>> SaveWorkOrder(MaintenanceTicketWorkOrder workOrder)
        {
            if (workOrder.WorkOrderId.HasValue)
            {
                return PostAsync<BaseResponse<MaintenanceTicketWorkOrder>, MaintenanceTicketWorkOrder>("UpdateWorkOrder",
                                                                                                       workOrder,
                                                                                                       default(CancellationToken),
                                                                                                       AddAccessToken);
            }
            else
            {
                return PostAsync<BaseResponse<MaintenanceTicketWorkOrder>, MaintenanceTicketWorkOrder>("CreateWorkOrder",
                                                                                                       workOrder,
                                                                                                       default(CancellationToken),
                                                                                                       AddAccessToken);
            }
        }

        public Task<BaseResponse<MaintenanceTicketEvent>> SaveEvent(MaintenanceTicketEvent evt)
        {
            if (evt.EventId.HasValue)
            {
                return PostAsync<BaseResponse<MaintenanceTicketEvent>, MaintenanceTicketEvent>("UpdateEvent",
                                                                                                       evt,
                                                                                                       default(CancellationToken),
                                                                                                       AddAccessToken);
            }
            else
            {
                return PostAsync<BaseResponse<MaintenanceTicketEvent>, MaintenanceTicketEvent>("CreateEvent",
                                                                                                       evt,
                                                                                                       default(CancellationToken),
                                                                                                       AddAccessToken);
            }
        }
    }
}
