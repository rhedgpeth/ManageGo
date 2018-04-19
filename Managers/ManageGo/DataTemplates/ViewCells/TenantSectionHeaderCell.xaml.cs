using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class TenantSectionHeaderCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(TenantSectionHeaderCell));

        public TenantSectionHeaderCell()
        {
            InitializeComponent();
        }
    }
}
