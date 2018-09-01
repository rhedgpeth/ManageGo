using System.Linq;
using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TenantSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public TenantSectionHeaderViewModel(Tenant tenant)
        {
            LoadTenant(tenant);
        }

        void LoadTenant(Tenant tenant)
        {
            Name = $"{tenant.TenantFirstName} {tenant.TenantLastName}".Trim();
            Address = string.Join(", ", tenant.TenantUnits.Select(x => x.ShortName));;
            Children = new List<object>
                                    {
                                        new TenantDetailsViewModel
                                        {
                                            Email = tenant.TenantEmailAddress,
                                            HomePhoneNumber = tenant.TenantHomePhone,
                                            CellPhoneNumber = tenant.TenantCellPhone
                                        }
            };
        }
    }
}
