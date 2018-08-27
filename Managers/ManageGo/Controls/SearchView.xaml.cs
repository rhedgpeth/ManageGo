using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class SearchView : Grid
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                                                        typeof(string),
                                                                                        typeof(SearchView),
                                                                                       default(string),
                                                                                       BindingMode.TwoWay);
                                                                                       //, 
                                                                                       //propertyChanged: HandleTextPropertyChanged);


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }

        /*
        static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var sv = bindable as SearchView;
            sv.editor.Text = (string)newValue;
        }*/

        public SearchView()
        {
            InitializeComponent();

            //BindingContext = this;
        }
    }
}
