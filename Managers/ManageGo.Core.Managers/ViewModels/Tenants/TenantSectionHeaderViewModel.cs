using System;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TenantSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public TenantSectionHeaderViewModel()
        { }
    }
}
