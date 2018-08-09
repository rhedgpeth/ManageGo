using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class TenantService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<TenantService> lazy = new Lazy<TenantService>(() => new TenantService());
        public static TenantService Instance { get { return lazy.Value; } }

        TenantService() { }

        public Task<BaseResponse<List<Tenant>>> GetTenants(TenantRequest request)
            => PostAsync<BaseResponse<List<Tenant>>, TenantRequest>("tenants", request, default(CancellationToken), AddAccessToken);
    }
}
