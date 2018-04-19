using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
	public partial class PaymentSectionHeaderCell : ViewCell
    {
		public static readonly DataTemplate Template = new DataTemplate(typeof(PaymentSectionHeaderCell));

        public PaymentSectionHeaderCell()
        {
            InitializeComponent();
        }
    }
}
