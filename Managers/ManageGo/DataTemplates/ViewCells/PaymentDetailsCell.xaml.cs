using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class PaymentDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(PaymentDetailsCell));

        public PaymentDetailsCell()
        {
            InitializeComponent();
        }
    }
}
