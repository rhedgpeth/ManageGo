using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ManageGo.UI.Controls
{
	public class TappableLabel : Label
    {
		public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(ListView));
        
		public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public TappableLabel()
        {         
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(OnLabelTapped)
            });
        }

		void OnLabelTapped()
        {
            if (TappedCommand != null && TappedCommand.CanExecute(null))
            {
                TappedCommand.Execute(null);
            }
        }
    }
}
