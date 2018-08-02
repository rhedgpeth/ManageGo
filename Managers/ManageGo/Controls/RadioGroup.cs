using System;
using System.Collections;
using System.Collections.Generic;
using ManageGo.Core.Events;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public class RadioGroup : StackLayout
    {
        public List<RadioButton> rads;

        public RadioGroup()
        {

            rads = new List<RadioButton>();
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<RadioGroup, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);


        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<RadioGroup, int>(o => o.SelectedIndex, default(int), BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public event EventHandler<int> CheckedChanged;

        static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var radButtons = bindable as RadioGroup;

            radButtons.rads.Clear();
            radButtons.Children.Clear();

            if (newvalue != null)
            {

                int radIndex = 0;
                foreach (var item in newvalue)
                {
                    var rad = new RadioButton();
                    rad.Text = item.ToString();
                    rad.Id = radIndex;

                    rad.CheckedChanged += radButtons.OnCheckedChanged;

                    radButtons.rads.Add(rad);

                    radButtons.Children.Add(rad);
                    radIndex++;
                }
            }
        }

        void OnCheckedChanged(object sender, EventArgs<bool> e)
        {

            if (e.Value == false) return;

            var selectedRad = sender as RadioButton;

            foreach (var rad in rads)
            {
                if (!selectedRad.Id.Equals(rad.Id))
                {
                    rad.Checked = false;
                }
                else
                {
                    if (CheckedChanged != null)
                        CheckedChanged.Invoke(sender, rad.Id);

                }
            }
        }

        static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            if (newvalue == -1) return;

            var bindableRadioGroup = bindable as RadioGroup;

            foreach (var rad in bindableRadioGroup.rads)
            {
                if (rad.Id == bindableRadioGroup.SelectedIndex)
                {
                    rad.Checked = true;
                }

            }
        }
    }
}
