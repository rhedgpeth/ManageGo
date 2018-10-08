using ManageGo.Core.Managers.Models;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class PaymentView : StackLayout
    {
        public PaymentView(PaymentBase payment, bool showSeparator)
        {
            InitializeComponent();

            AmountLabel.Text = payment.Amount.ToString("c");
            DateTimeLabel.Text = $" • {payment.TransactionDate}";
            TransactionNumberLabel.Text = $" • {payment.TransactionNumber}";
            AddressLabel.Text = $"{payment.Tenant?.TenantFirstName} {payment.Tenant?.TenantLastName}, " +
                                $"{payment.Building?.BuildingShortAddress}, " +
                                $"{payment.Unit?.UnitName}";
            SeparatorBoxView.IsVisible = showSeparator;
        }
    }
}
