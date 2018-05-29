﻿using System;
using Xamarin.Forms;

namespace ManageGo.UI.Controls
{
    public partial class EditableLabel : Grid
    {
		public static readonly BindableProperty ValueProperty
            = BindableProperty.Create(nameof(Value),
                                      typeof(string),
                                      typeof(EditableLabel),
                                      string.Empty,
                                      BindingMode.TwoWay,
		                              propertyChanged: HandleValuePropertyChanged);

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        
		static void HandleValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var editableLabel = bindable as EditableLabel;
            editableLabel.entry.Text = editableLabel.label.Text = (string)newValue;         
        }
              
		public static readonly BindableProperty EditIconProperty 
		                = BindableProperty.Create(nameof(EditIcon),
                                                  typeof(string),
		                                          typeof(EditableLabel),
                                                  string.Empty,
                                                  propertyChanged: HandleEditIconPropertyChanged);

        public bool EditIcon
        {
            get { return (bool)GetValue(EditIconProperty); }
            set { SetValue(EditIconProperty, value); }
        }

        static void HandleEditIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
			var editableLabel = bindable as EditableLabel;
			editableLabel.imageEditIcon.Source = (string)newValue;
        }


        public EditableLabel()
        {
            InitializeComponent();
			//BindingContext = this;
        }

		void Handle_Tapped(object sender, EventArgs e)
        {            
			label.IsVisible = !label.IsVisible;
			entry.IsVisible = !label.IsVisible;
        }
    }
}