using System;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class FilterView : Grid
    {      
		StackLayout _expandableLayout;

		public virtual StackLayout ExpandableLayout
        {
			get { return _expandableLayout; }
            set
            {
				_expandableLayout = value;

				//foreach (var child in _expandableLayout.Children)
				//{
					ExpandableLayoutRegion.Children.Add(_expandableLayout);
				//}
                
				OnPropertyChanged();
            }
        }
        
		public static readonly BindableProperty ShowCalendarProperty = BindableProperty.Create(nameof(ShowCalendar),
                                                                                        typeof(bool),
		                                                                                       typeof(FilterView),
                                                                                        true,
                                                                                        propertyChanged: HandleShowCalendarPropertyChanged);
        

        public bool ShowCalendar
        {
			get { return (bool)GetValue(ShowCalendarProperty); }
			set { SetValue(ShowCalendarProperty, value); }
        }

		static void HandleShowCalendarPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;

			if (!(bool)newValue)
			{
				filter.CalendarTappableLabel.IsVisible = false;
				filter.SeparatorBoxView.IsVisible = false;

				SetColumn(filter.FilterTappableLabel, 0);
				SetColumnSpan(filter.FilterTappableLabel, 3);
			}
        }

        public FilterView()
        {
            InitializeComponent();

            /*
            if (!ShowCalendar)
			{
				CalendarTappableLabel.IsVisible = false;
                SeparatorBoxView.IsVisible = false;

                SetColumn(FilterTappableLabel, 0);
                SetColumnSpan(FilterTappableLabel, 3);
			}*/

			SubscribeToGuestureHandlers();
        }
        
		void SubscribeToGuestureHandlers()
        {
			FilterTappableLabel.Tapped += FilterLabel_Tapped;
        }

		void FilterLabel_Tapped(object sender, EventArgs e)
        {
			if (ExpandableLayoutRegion.IsVisible)
			{
				ExpandableLayoutRegion.IsVisible = false;
            }
            else
            {
				ExpandableLayoutRegion.IsVisible = true;
            }
        }
    }
}
