using System;
using System.Linq;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public class ExpandableViewCell : ViewCell
    {
        public static readonly BindableProperty MyHeightProperty =
            BindableProperty.Create("MyHeight", typeof(string), typeof(ExpandableViewCell), "");

        public string MyHeight
        {
            get => (string)GetValue(MyHeightProperty);
            set => SetValue(MyHeightProperty, value);
        }

        StaticContent StaticContent
        {
            get
            {

               

                var rootStackLayout = View as CellContent;
                return rootStackLayout?.Children?.FirstOrDefault(c => c.GetType() == typeof(StaticContent)) as StaticContent;
            }
        }

        ToggleButton ToggleButton 
        {
            get
            {
                return StaticContent.Children.FirstOrDefault(c => c.GetType() == typeof(ToggleButton)) as ToggleButton;
            }
        }

        ExpandableContent ExpandableContent
        {
            get
            {
                var rootStackLayout = View as CellContent;
                return rootStackLayout?.Children?.FirstOrDefault(c => c.GetType() == typeof(ExpandableContent)) as ExpandableContent;
            }
        }

        public ExpandableViewCell()
        {
            // row height
            //this.Height = 200;


        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            ToggleButton.Clicked += (sender, e) =>
            {
                //var heightValue = (string)GetValue(MyHeightProperty);
                //this.Height = 50;
                //this.ForceUpdateSize();

                /*
                var dropAnimation = new Animation(d =>
                {
                    Height = d;
                    ForceUpdateSize();
                }
                , Height, 0, Easing.BounceIn);

                dropAnimation.Commit(ExpandableContent, "DropSize", 16, (uint)350, Easing.Linear);
                */

                if (ExpandableContent.IsVisible)
                {
                    ExpandableContent.IsVisible = false;
                    //ToggleButton.Text = ToggleButton.CollapsedText;
                }
                else
                {
                    ExpandableContent.IsVisible = true;
                    //ToggleButton.Text = ToggleButton.ExpandedText;
                }

                //this.ForceUpdateSize();
            };
		}

		// when binding context is changed!
		protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //MyModel myModel = (MyModel)BindingContext;

            //this.Height = Convert.ToDouble(myModel.RowHeight);
            //this.ForceUpdateSize();

            System.Diagnostics.Debug.WriteLine("Binding Contex Changed!");
        }
    }

    public class ToggleButton : Button
    { 
        public string ExpandedText { get; set; }
        public string CollapsedText { get; set; }
    }

    public class CellContent : StackLayout
    { }

    public class StaticContent : StackLayout
    { }

    public class ExpandableContent : StackLayout
    { 
        public ExpandableContent()
        {
            IsVisible = false;
        }
    }
}
