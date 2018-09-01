using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using ManageGo.Core.Managers.Models;
using Xamarin.Forms;
using System.Collections;

namespace ManageGo.Controls
{
    public partial class CheckboxList : ListView
    {
        public string ItemTypeDescription { get; set; }

        public static readonly BindableProperty SelectedItemsProperty 
                = BindableProperty.Create(nameof(SelectedItems),
                                        typeof(IList<SelectableItem>),
                                          typeof(CheckboxList), default(List<SelectableItem>), BindingMode.TwoWay); //,
                                                                                                                    //propertyChanged: HandleItemSourcePropertyChanged);

        List<SelectableItem> _selectedItems = new List<SelectableItem>();
        public IList<SelectableItem> SelectedItems
        {
            get { return (IList<SelectableItem>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly BindableProperty SelectedItemsDescriptionProperty
                = BindableProperty.Create(nameof(SelectedItemsDescription),
                                          typeof(string),
                                        typeof(CheckboxList), default(string), BindingMode.TwoWay); //,
                                                                                   //propertyChanged: HandleItemSourcePropertyChanged);

        public string SelectedItemsDescription
        {
            get { return (string)GetValue(SelectedItemsDescriptionProperty); }
            set { SetValue(SelectedItemsDescriptionProperty, value); }
        }

        public CheckboxList()
        {
            InitializeComponent();
        }

        void UpdateSelectedItemsDescription(string singleDescription)
        {
            if (_selectedItems.Count == 0 || _selectedItems.Count == _totalItemCount)
            {
                SelectedItemsDescription = "All";
            }
            else if (_selectedItems.Count == 1)
            {
                SelectedItemsDescription = singleDescription;
            }
            else
            {
                SelectedItemsDescription = $"{_selectedItems.Count} {ItemTypeDescription}";
            }
        }

        int _totalItemCount;

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _totalItemCount = 0;

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
                            else if (target.Id == -1)
                            {
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

                            if (target.Id >= 0)
                            {
                                _totalItemCount++;

                                if (target.IsSelected && !_selectedItems.Contains(target))
                                {
                                    _selectedItems.Add(target);
                                }
                                else if (!target.IsSelected && _selectedItems.Contains(target))
                                {
                                    _selectedItems.Remove(target);
                                }
                            }
                        }
                    }

                    UpdateSelectedItemsDescription(item.Description);
                    SelectedItems = _selectedItems;

                    if (rootItem != null)
                    {
                        rootItem.IsSelected = (allChecked || allUnchecked);
                    }
                }
            }
        }
    }
}
