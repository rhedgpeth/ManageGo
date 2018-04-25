using System;
using ManageGo.UI.Controls;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class FilterView : Grid
    {            
		StackLayout _leftExpandableLayout;

        public virtual StackLayout LeftExpandableLayout
        {
            get { return _leftExpandableLayout; }
            set
            {
                _leftExpandableLayout = value;
                LeftExpandableLayoutRegion.Children.Add(_leftExpandableLayout);
                OnPropertyChanged();
            }
        }

		StackLayout _rightExpandableLayout;

		public virtual StackLayout RightExpandableLayout
        {
			get { return _rightExpandableLayout; }
            set
            {
				_rightExpandableLayout = value;
				RightExpandableLayoutRegion.Children.Add(_rightExpandableLayout);
				OnPropertyChanged();
            }
        }
        
		public static readonly BindableProperty ShowRightFilterProperty = BindableProperty.Create(nameof(ShowRightFilter),
                                                                                        typeof(bool),
		                                                                                       typeof(FilterView),
                                                                                        true,
                                                                                        propertyChanged: HandleShowLeftFilterPropertyChanged);
        
        
        public bool ShowRightFilter
        {
			get { return (bool)GetValue(ShowRightFilterProperty); }
			set { SetValue(ShowRightFilterProperty, value); }
        }

		static void HandleShowLeftFilterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;

			if (!(bool)newValue)
			{
				filter.RightFilterTappableLabel.IsVisible = false;
				filter.SeparatorBoxView.IsVisible = false;

				SetColumnSpan(filter.LeftFilterTappableLabel, 3);
			}
        }
        
		public static readonly BindableProperty RightFilterTextProperty = BindableProperty.Create(nameof(RightFilterText),
                                                                                        typeof(string),
		                                                                                          typeof(FilterView),
                                                                                        string.Empty,
                                                                                        propertyChanged: HandleRightFilterTextPropertyChanged);


        public bool RightFilterText
        {
            get { return (bool)GetValue(ShowRightFilterProperty); }
            set { SetValue(ShowRightFilterProperty, value); }
        }
        
        static void HandleRightFilterTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;
            filter.RightFilterTappableLabel.Text = (string)newValue;
        }

		public static readonly BindableProperty LeftFilterTextProperty = BindableProperty.Create(nameof(LeftFilterText),
                                                                                        typeof(string),
                                                                                                  typeof(FilterView),
                                                                                        string.Empty,
                                                                                        propertyChanged: HandleLeftFilterTextPropertyChanged);
        

        public bool LeftFilterText
        {
            get { return (bool)GetValue(ShowRightFilterProperty); }
            set { SetValue(ShowRightFilterProperty, value); }
        }

        static void HandleLeftFilterTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;
            filter.LeftFilterTappableLabel.Text = (string)newValue;
        }
      
        public FilterView()
        {
            InitializeComponent();
                     
			SubscribeToGuestureHandlers();
        }
        
		void SubscribeToGuestureHandlers()
        {
			LeftFilterTappableLabel.Tapped += LeftFilterLabel_Tapped;
			RightFilterTappableLabel.Tapped += RightFilterLabel_Tapped;
        }

		void LeftFilterLabel_Tapped(object sender, EventArgs e) => ToggleLayouts(LeftExpandableLayoutRegion, RightExpandableLayoutRegion);

		void RightFilterLabel_Tapped(object sender, EventArgs e) => ToggleLayouts(RightExpandableLayoutRegion, LeftExpandableLayoutRegion);

		void ToggleLayouts(StackLayout l1, StackLayout l2)
		{
			if (l1 != null)
			{
				l1.IsVisible = !l1.IsVisible;
			}

			if (l2 != null)
			{
				l2.IsVisible = false;
			}
        }
    }
}
