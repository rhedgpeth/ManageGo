using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class TenantDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(TenantDetailsCell));

        public TenantDetailsCell()
        {
            InitializeComponent();
        }
    }
}
