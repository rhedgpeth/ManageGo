using System;
using CustomCalendar;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class Calendar : View
    {
        public event CurrentMonthYearHandler OnMonthYearChanged;
        public event DateRangeHandler OnSelectedDatesChanged;

		public bool AllowMultipleSelection { get; set; }

        public static readonly BindableProperty SelectedDatesProperty
            = BindableProperty.Create(nameof(SelectedDates),
                                      typeof(DateRange),
                                      typeof(Calendar),
                                      new DateRange(DateTime.Now),
                                      BindingMode.TwoWay);

        public DateRange SelectedDates
        {
            get => (DateRange)GetValue(SelectedDatesProperty);
            set => SetValue(SelectedDatesProperty, value);
        }

		public static readonly BindableProperty CurrentMonthYearProperty
            = BindableProperty.Create(nameof(CurrentMonthYear),
                                      typeof(DateTime),
                                      typeof(Calendar),
                                      DateTime.Now,
                                      BindingMode.TwoWay);

        public DateTime CurrentMonthYear
        {
			get => (DateTime)GetValue(CurrentMonthYearProperty);
			set => SetValue(CurrentMonthYearProperty, value);
        }

        public void OnCurrentMonthYearChanged(DateTime date) => OnMonthYearChanged?.Invoke(date);
        public void OnDatesChanged(DateRange dates) => OnSelectedDatesChanged?.Invoke(dates);
    }
}
