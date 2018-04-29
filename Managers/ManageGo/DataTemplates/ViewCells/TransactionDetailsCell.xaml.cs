using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class TransactionDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(TransactionDetailsCell));

        public TransactionDetailsCell()
        {
            InitializeComponent();
        }
    }
}
