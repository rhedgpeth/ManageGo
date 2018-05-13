using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class CalendarSectionHeaderCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(CalendarSectionHeaderCell));

        public CalendarSectionHeaderCell()
        {
            InitializeComponent();
        }
    }
}
