using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using ManageGo.Core.Managers.Models;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public class CheckboxItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
    }

    public partial class CheckboxList : ListView
    {
        /*
        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(nameof(ItemSource),
                                                                                        typeof(IEnumerable),
                                                                                             typeof(CheckboxList));//,
                                                                                        //propertyChanged: HandleItemSourcePropertyChanged);

        static void HandleItemSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Console.WriteLine("ItemSource changed");
        }

        public IEnumerable ItemSource
        {
            get { return (IEnumerable)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }*/

        public CheckboxList()
        {
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is SelectableItem item)
            {
                item.IsSelected = !item.IsSelected;

                var pInfos = (this as ItemsView<Cell>).GetType().GetRuntimeProperties();

                var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");

                if (templatedItems != null)
                {
                    SelectableItem rootItem = null;

                    bool allChecked = true;
                    bool allUnchecked = true;

                    var cells = templatedItems.GetValue(this);

                    foreach (var cell in cells as ITemplatedItemsList<Cell>)
                    {
                        if (cell?.BindingContext is SelectableItem target)
                        {
                            if (item.Id == -1)
                            {
                                target.IsSelected = item.IsSelected;
                            }
                            else if (target.Id == -1) //&& target.IsSelected && !item.IsSelected)
                            {
                                //target.IsSelected = false;

                                rootItem = target;
                            }
                            else
                            {
                                if (allChecked)
                                {
                                    allChecked = target.IsSelected;
                                }

                                if (allUnchecked)
                                {
                                    allUnchecked = !target.IsSelected;
                                }
                            }
                        }
                    }

                    if (rootItem != null)
                    {
                        rootItem.IsSelected = (allChecked || allUnchecked);
                    }
                }
            }
        }
    }
}
