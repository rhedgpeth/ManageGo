using System;
using System.Collections.Generic;
using System.Globalization;
using ManageGo.Core.ViewModels;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class CalendarView : Grid
    {
		public static readonly BindableProperty AllowMultipleSelectionProperty = BindableProperty.Create(nameof(AllowMultipleSelection),
                                                                                        typeof(bool),
                                                                                        typeof(CalendarView),
                                                                                        false,
		                                                                                                 propertyChanged: AllowMultipleSelectionPropertyChanged);


		public bool AllowMultipleSelection
        {
			get { return (bool)GetValue(AllowMultipleSelectionProperty); }
			set { SetValue(AllowMultipleSelectionProperty, value); }
        }

        static void AllowMultipleSelectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var calendarView = bindable as CalendarView;
            calendarView.calendar.AllowMultipleSelection = (bool)newValue;
        }

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
