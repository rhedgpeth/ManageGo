using System.Linq;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class TenantsViewModel : BaseExpandableCollectionViewModel<TenantSectionHeaderViewModel>
    {
        public TenantsViewModel()
        {
            Title = "Tenants";
        }

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new TenantRequest { Page = Page, PageSize = 20 };

            var tenantsResponse = await TenantService.Instance.GetTenants(request);

            if (tenantsResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                CanLoadMore = tenantsResponse.Result.Count == 20;

                var tenantsSectionHeaderViewModels = tenantsResponse.Result?.Select(x => new TenantSectionHeaderViewModel(x));

                LoadItems(refresh, tenantsSectionHeaderViewModels);
            }

            IsBusy = false;
        }
    }
}
