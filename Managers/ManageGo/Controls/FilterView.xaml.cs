using System;
using System.Windows.Input;
using ManageGo.UI.Controls;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class FilterView : Grid
    {
        StackLayout _titleLayout;

        public virtual StackLayout TitleLayout
        {
            get { return _titleLayout; }
            set
            {
                _titleLayout = value;
                TitleLayoutRegion.Children.Add(_titleLayout);
                OnPropertyChanged();
            }
        }

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
				filter.RightFilterOption.IsVisible = false;
				filter.SeparatorBoxView.IsVisible = false;
                
				SetColumnSpan(filter.LeftFilterOption, 3);
			}
        }
        
		public static readonly BindableProperty RightFilterIconProperty = BindableProperty.Create(nameof(RightFilterIcon),
                                                                                        typeof(string),
		                                                                                          typeof(FilterView),
                                                                                        string.Empty,
		                                                                                          propertyChanged: HandleRightFilterIconPropertyChanged);

        
        public bool RightFilterIcon
        {
			get { return (bool)GetValue(RightFilterIconProperty); }
			set { SetValue(RightFilterIconProperty, value); }
        }
        
        static void HandleRightFilterIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;
            filter.RightFilterImage.Source = (string)newValue;
        }

		public static readonly BindableProperty RightFilterTextProperty = BindableProperty.Create(nameof(RightFilterText),
                                                                                        typeof(string),
                                                                                                  typeof(FilterView),
                                                                                        string.Empty,
                                                                                        propertyChanged: HandleRightFilterTextPropertyChanged);


        public bool RightFilterText
        {
			get { return (bool)GetValue(RightFilterTextProperty); }
			set { SetValue(RightFilterTextProperty, value); }
        }

        static void HandleRightFilterTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;
            filter.RightFilterLabel.Text = (string)newValue;
        }

		public static readonly BindableProperty LeftFilterIconProperty = BindableProperty.Create(nameof(LeftFilterIcon),
																						typeof(string),
																								  typeof(FilterView),
																								 string.Empty,
                                                                                                  propertyChanged: HandleLeftFilterIconPropertyChanged);


        public bool LeftFilterIcon
        {
            get { return (bool)GetValue(LeftFilterIconProperty); }
            set { SetValue(LeftFilterIconProperty, value); }
        }

        static void HandleLeftFilterIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var filter = bindable as FilterView;
            filter.LeftFilterImage.Source = (string)newValue;
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
            filter.LeftFilterLabel.Text = (string)newValue;
        }
      
        public FilterView()
        {
            InitializeComponent();
        }

		void Handle_LeftFilterOption_Tapped(object sender, EventArgs e) => ToggleLayouts(LeftExpandableLayoutRegion, RightExpandableLayoutRegion, LeftFilterOption, RightFilterOption);

		void Handle_RightFilterOption_Tapped(object sender, EventArgs e) => ToggleLayouts(RightExpandableLayoutRegion, LeftExpandableLayoutRegion, RightFilterOption, LeftFilterOption);
        
		void ToggleLayouts(StackLayout expandableLayout1, StackLayout expandableLayout2, StackLayout filterLayout1, StackLayout filterLayout2)
		{
            if (expandableLayout1 != null)
			{
				filterLayout1.Opacity = 1;               
				expandableLayout1.IsVisible = !expandableLayout1.IsVisible;
                filterButton.IsVisible = expandableLayout1.IsVisible;
			}

			if (expandableLayout2 != null)
			{
                filterLayout2.Opacity = expandableLayout1.IsVisible ? .5 : 1;
				expandableLayout2.IsVisible = false;
			}
        }

        public static readonly BindableProperty ApplyFilterCommandProperty =
            BindableProperty.Create(nameof(ApplyFilterCommand), typeof(ICommand), typeof(FilterView));

        public ICommand ApplyFilterCommand
        {
            get { return (ICommand)GetValue(ApplyFilterCommandProperty); }
            set { SetValue(ApplyFilterCommandProperty, value); }
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            LeftExpandableLayoutRegion.IsVisible = false;
            LeftFilterOption.Opacity = 1;

            RightExpandableLayoutRegion.IsVisible = false;
            RightFilterOption.Opacity = 1;

            filterButton.IsVisible = false;

            if (ApplyFilterCommand != null && ApplyFilterCommand.CanExecute(null))
            {
                ApplyFilterCommand.Execute(null);
            }
        }
    }
}
