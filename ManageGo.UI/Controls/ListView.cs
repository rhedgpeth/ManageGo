using System.Windows.Input;
using Xamarin.Forms;

namespace ManageGo.UI.Controls
{
    public class ListView : Xamarin.Forms.ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(nameof(ItemTappedCommand), typeof(ICommand), typeof(ListView));

        public ListView()
        {
            ItemTapped += OnItemTapped;
        }

        public ListView(ListViewCachingStrategy strategy) : base(Device.RuntimePlatform.Equals("iOS")
                                                                 ? ListViewCachingStrategy.RetainElement : strategy)
        {
            ItemTapped += OnItemTapped;
        }

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && ItemTappedCommand != null && ItemTappedCommand.CanExecute(e))
            {
                ItemTappedCommand.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}
