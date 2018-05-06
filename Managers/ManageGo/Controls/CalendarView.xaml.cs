using System;
using System.Collections.Generic;
using System.Globalization;
using ManageGo.Core.ViewModels;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class CalendarView : Grid
    {
        public CalendarView()
        {
            InitializeComponent();

			BindingContext = new CalendarViewModel();
        }
    }

	public class CalendarViewModel : BaseViewModel
	{
        public string CurrentMonthYearDescription
		{
			get
			{
				return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(CurrentMonthYear.Month)}, {CurrentMonthYear.Year}";
			}
		}

		DateTime _currentMonthYear;
        public DateTime CurrentMonthYear
		{
			get => _currentMonthYear;
			set 
			{
				SetPropertyChanged(ref _currentMonthYear, value);
				SetPropertyChanged(nameof(CurrentMonthYearDescription));
			}
		}
	}
}
