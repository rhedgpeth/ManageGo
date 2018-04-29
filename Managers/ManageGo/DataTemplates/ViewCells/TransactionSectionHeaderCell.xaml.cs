using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
	public partial class TransactionSectionHeaderCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(TransactionSectionHeaderCell));

        public TransactionSectionHeaderCell()
        {
            InitializeComponent();
        }
    }
}
