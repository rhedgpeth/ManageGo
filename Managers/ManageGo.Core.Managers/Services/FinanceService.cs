using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class FinanceService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<FinanceService> lazy = new Lazy<FinanceService>(() => new FinanceService());
        public static FinanceService Instance { get { return lazy.Value; } }

        FinanceService() { }

        public Task<BaseResponse<List<Payment>>> GetPayments(PaymentRequest request)
            => PostAsync<BaseResponse<List<Payment>>, PaymentRequest>("payments", 
                                                                      request, 
                                                                      default(CancellationToken), 
                                                                      AddAccessToken);

        public Task<BaseResponse<List<BankTransaction>>> GetBankTransactions(BankTransactionRequest request)
            => PostAsync<BaseResponse<List<BankTransaction>>, BankTransactionRequest>("banktransactions", 
                                                                                      request, 
                                                                                      default(CancellationToken), 
                                                                                      AddAccessToken);

        public Task<BaseResponse<List<BankAccount>>> GetBankAccounts()
            => PostAsync<BaseResponse<List<BankAccount>>>("bankaccounts", default(CancellationToken), AddAccessToken);
    }
}
