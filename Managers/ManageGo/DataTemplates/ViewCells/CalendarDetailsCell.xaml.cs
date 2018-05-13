using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
    public partial class CalendarDetailsCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(CalendarDetailsCell));

        public CalendarDetailsCell()
        {
            InitializeComponent();
        }
    }
}
