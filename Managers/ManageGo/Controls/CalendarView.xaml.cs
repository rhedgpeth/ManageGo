using System;
using System.Globalization;
using CustomCalendar;
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

            bool allowMultiplSelection = (bool)newValue;

            calendarView.calendar.AllowMultipleSelection = allowMultiplSelection;
            calendarView.past7DaysButton.IsVisible = allowMultiplSelection;
            calendarView.past30DaysButton.IsVisible = allowMultiplSelection;
        }

        public static readonly BindableProperty SelectedDateProperty
            = BindableProperty.Create(nameof(SelectedDate),
                                      typeof(DateTime),
                                      typeof(CalendarView),
                                      DateTime.Now, 
                                      BindingMode.TwoWay);

        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set
            {
                SetValue(SelectedDateProperty, value);
            }
        }

        public static readonly BindableProperty SelectedDatesProperty
            = BindableProperty.Create(nameof(SelectedDates),
                                      typeof(DateRange),
                                      typeof(CalendarView),
                                      new DateRange(DateTime.Now),
                                      BindingMode.TwoWay);

        public DateRange SelectedDates
        {
            get => (DateRange)GetValue(SelectedDatesProperty);
            set
            {
                SetValue(SelectedDatesProperty, value);
            }
        }

        public CalendarView()
        {
            InitializeComponent();
        }

        void Handle_OnSelectedDatesChanged(DateRange dates)
        {
            SelectedDate = dates.StartDate;
            SelectedDates = dates;
        }

        void Handle_OnMonthYearChanged(DateTime date)
        {
            titleLabel.Text = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month)}, {date.Year}";
        }
    }
}
