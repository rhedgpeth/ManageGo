using System.Collections.Generic;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class TransactionDetailsViewModel : BaseViewModel
    {
        List<PaymentBase> _payments;
        public List<PaymentBase> Payments 
        {
            get => _payments;
            set => SetPropertyChanged(ref _payments, value);
        }

        public TransactionDetailsViewModel(List<PaymentBase> payments)
        {
            Payments = payments;
        }
    }
}
