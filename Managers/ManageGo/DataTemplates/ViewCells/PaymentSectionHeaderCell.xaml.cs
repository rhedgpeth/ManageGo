﻿using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.ViewModels;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
	public partial class PaymentSectionHeaderCell : ViewCell //BaseSectionHeaderCell<PaymentSectionHeaderViewModel>
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(PaymentSectionHeaderCell));

        public PaymentSectionHeaderCell()
        {
            InitializeComponent();
        }
              
		protected override void OnTapped()
        {
            base.OnTapped();
            
            /*
			if (BindingContext is PaymentSectionHeaderViewModel section)
				toggleButton.Text = section.IsExpanded ? "Close" : "Open";
			*/
		}
    }
}