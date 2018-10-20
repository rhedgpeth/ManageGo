using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class NumericRangeView : Grid
    {
        public static readonly BindableProperty FromAmountProperty = BindableProperty.Create(nameof(FromAmount),
                                                                                        typeof(int),
                                                                                        typeof(NumericRangeView),
                                                                                        -1,
                                                                                        BindingMode.TwoWay, 
                                                                                        propertyChanged: FromAmountPropertyChanged);


        public int FromAmount
        {
            get { return (int)GetValue(FromAmountProperty); }
            set { SetValue(FromAmountProperty, value); }
        }

        static void FromAmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var numericRangeView = bindable as NumericRangeView;
            numericRangeView.FromAmountEntry.Text = newValue.ToString();
        }

        public static readonly BindableProperty ToAmountProperty = BindableProperty.Create(nameof(ToAmount),
                                                                                        typeof(int),
                                                                                        typeof(NumericRangeView),
                                                                                        -1,
                                                                                        BindingMode.TwoWay,
                                                                                        propertyChanged: ToAmountPropertyChanged);

        public int ToAmount
        {
            get { return (int)GetValue(ToAmountProperty); }
            set { SetValue(ToAmountProperty, value); }
        }

        static void ToAmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var numericRangeView = bindable as NumericRangeView;
            numericRangeView.ToAmountEntry.Text = newValue.ToString();
        }

        public NumericRangeView()
        {
            InitializeComponent();
        }

        void Handle_FromText_Changed(object sender, TextChangedEventArgs e)
        {
            FromAmount = int.TryParse(e.NewTextValue, out int result) ? result : 0;
        }

        void Handle_ToText_Changed(object sender, TextChangedEventArgs e)
        {
            ToAmount = int.TryParse(e.NewTextValue, out int result) ? result : 0;
        }
    }
}
