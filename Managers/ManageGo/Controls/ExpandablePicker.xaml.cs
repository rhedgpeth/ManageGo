using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class ExpandablePicker : Grid
    {      
		StackLayout _expandableLayout;

        public virtual StackLayout ExpandableLayout
        {
            get { return _expandableLayout; }
            set
            {
                _expandableLayout = value;

                ExpandableLayoutRegion.Children.Add(_expandableLayout);

                OnPropertyChanged();
            }
        }

		public static readonly BindableProperty DescriptorProperty = BindableProperty.Create(nameof(Descriptor),
                                                                                        typeof(string),
		                                                                                     typeof(ExpandablePicker),
                                                                                        default(string),
                                                                                        propertyChanged: HandleDescriptorPropertyChanged);


        public string Descriptor
        {
			get { return (string)GetValue(DescriptorProperty); }
			set { SetValue(DescriptorProperty, value); }
        }
        
		static void HandleDescriptorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = bindable as ExpandablePicker;
            picker.DescriptorLabel.Text = newValue as string;
        }

		public static readonly BindableProperty SelectedTextProperty = BindableProperty.Create(nameof(SelectedText),
                                                                                        typeof(string),
		                                                                                       typeof(ExpandablePicker),
                                                                                        default(string),
                                                                                        propertyChanged: HandleSelectedTextPropertyChanged);


        public string SelectedText
        {
			get { return (string)GetValue(SelectedTextProperty); }
            set { SetValue(SelectedTextProperty, value); }
        }

        static void HandleSelectedTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = bindable as ExpandablePicker;
            picker.SelectedTextLabel.Text = newValue as string;
        }

        public ExpandablePicker()
        {
            InitializeComponent();
        }
  
		void Handle_Tapped(object sender, EventArgs e)
        {
			if (ExpandableLayoutRegion.IsVisible)
            {
				chevronImage.RotateTo(0);
                ExpandableLayoutRegion.IsVisible = false;
            }
            else
            {
				chevronImage.RotateTo(180);
                ExpandableLayoutRegion.IsVisible = true;
            }
        }
    }
}
