using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public class PaymentsGrid : Grid
    {
        public static readonly BindableProperty PaymentsProperty
            = BindableProperty.Create(nameof(Payments),
                                      typeof(List<PaymentBase>),
                                      typeof(PaymentsGrid),
                                      new List<PaymentBase>(),
                                      BindingMode.TwoWay,
                                      propertyChanged: HandlePaymentsPropertyChanged);

        public List<PaymentBase> Payments
        {
            get => (List<PaymentBase>)GetValue(PaymentsProperty);
            set => SetValue(PaymentsProperty, value);
        }

        static void HandlePaymentsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var grid = bindable as PaymentsGrid;

            if (newValue != null)
            {
                var payments = newValue as List<PaymentBase>;

                grid.ColumnDefinitions.Add(new ColumnDefinition());

                for (int i = 0; i < payments.Count; i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                }

                int count = 0;
                foreach (var payment in payments)
                {
                    grid.Children.Add(new PaymentView(payment, count <= payments.Count), 0, count);
                    count++;
                }
            }
        }

        public PaymentsGrid()
        {
            RowSpacing = 10;
        }
    }
}
