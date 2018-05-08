using System;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class Calendar : View
    {
		public bool AllowMultipleSelection { get; set; }

        public static readonly BindableProperty SelectedDateProperty
            = BindableProperty.Create(nameof(SelectedDate),
                                      typeof(DateTime),
                                      typeof(Calendar),
                                      DateTime.Now,
                                      BindingMode.TwoWay);

        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

		public static readonly BindableProperty CurrentMonthYearProperty
            = BindableProperty.Create(nameof(SelectedDate),
                                      typeof(DateTime),
                                      typeof(Calendar),
                                      DateTime.Now,
                                      BindingMode.TwoWay);

        public DateTime CurrentMonthYear
        {
			get => (DateTime)GetValue(CurrentMonthYearProperty);
			set => SetValue(CurrentMonthYearProperty, value);
        }
    }
}
