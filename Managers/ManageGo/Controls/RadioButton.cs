using System;
using ManageGo.Core.Events;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public class RadioButton : View
    {
        public static readonly BindableProperty CheckedProperty =
                   BindableProperty.Create<RadioButton, bool>(
                       p => p.Checked, false);

        /// <summary>
        /// The default text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<RadioButton, string>(
                p => p.Text, string.Empty);

        /// <summary>
        /// The checked changed event.
        /// </summary>
        public EventHandler<EventArgs<bool>> CheckedChanged;


        /// <summary>
        /// Identifies the TextColor bindable property.
        /// </summary>
        /// 
        /// <remarks/>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<RadioButton, Color>(
                p => p.TextColor, Color.Black);

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }

            set
            {
                SetValue(CheckedProperty, value);

                var eventHandler = CheckedChanged;

                if (eventHandler != null)
                {

                    eventHandler.Invoke(this, value);
                }
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public int Id { get; set; }
    }
}