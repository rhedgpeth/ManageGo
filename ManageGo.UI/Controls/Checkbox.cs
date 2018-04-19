using System;

using Xamarin.Forms;

namespace ManageGo.UI.Controls
{
	public class Checkbox : Button
    {
        public Checkbox()
        {
            base.Image = "Assets/newcbu.png";
            base.Clicked += OnClicked;
            base.BackgroundColor = Color.Transparent;
            base.BorderWidth = 0;
        }

        public static BindableProperty CheckedProperty = BindableProperty.Create(
            propertyName: "Checked",
            returnType: typeof(Boolean?),
            declaringType: typeof(Checkbox),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: CheckedValueChanged);

        public Boolean? Checked
        {
            get
            {
                if (GetValue(CheckedProperty) == null)
                {
                    return null;
                }

                return (Boolean)GetValue(CheckedProperty);
            }
            set
            {
                SetValue(CheckedProperty, value);

                OnPropertyChanged();

                RaiseCheckedChanged();
            }
        }

        static void CheckedValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
			if (newValue != null && (Boolean)newValue == true)
			{
				((Checkbox)bindable).Image = "checkedimage.png";
			}
			else
			{
				((Checkbox)bindable).Image = "uncheckedimage.png";
			}
        }

        public event EventHandler CheckedChanged;

        void RaiseCheckedChanged()
        {
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }

        public void OnClicked(object sender, EventArgs e)
        {
            Checked = !Checked;
        }      
    }
}

