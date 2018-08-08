using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
	public class BuildingService : BaseAuthenticatedHttpService
    {
		static readonly Lazy<BuildingService> lazy = new Lazy<BuildingService>(() => new BuildingService());
		public static BuildingService Instance { get { return lazy.Value; } }

		BuildingService() { }

        public Task<BaseResponse<List<Building>>> GetBuildings(PagedRequest request) 
            => PostAsync<BaseResponse<List<Building>>, PagedRequest>("buildings", 
                                                                     request, 
                                                                     default(CancellationToken), 
                                                                     AddAccessToken);

		//public Task<List<Unit>> GetUnits(int buildingId) => GetAsync<List<Unit>>("building/{buildingId}/units");
        public Task<List<Unit>> GetUnits(int buildingId)
		{
			return Task.Run(() =>
			{
				var units = new List<Unit>();
                          
				var letters = new string[] { "A", "B", "C", "D", "E", "F" };

                foreach (var letter in letters)
				{
					for (int i = 1; i < 5; i++)
					{
						units.Add(new Unit { BuildingId = 1, Number = $"{i}-{letter}", Tenants = GetMockedTenants((int)RandomNumberBetween(1,6)) });
					}
				}

				_tenantCount = 0;

				return units;
			});
		}
              
		int _tenantCount = 0;
        
        List<Tenant> GetMockedTenants(int count)
		{
			var tenants = new List<Tenant>();

			for (int i = 0; i < count; i++)
			{
				var tenant = new Tenant
				{
					Name = $"Tenant {_tenantCount++}"
				};

				tenants.Add(tenant);
			}

			return tenants;
		}
    }
}
