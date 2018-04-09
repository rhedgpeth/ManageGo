using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Skip)]
namespace ManageGo.Pages
{
    public partial class TransactionsPage : BaseSearchContentPage<TransactionsViewModel>
    {
        public TransactionsPage()
        {
            InitializeComponent();
        }
    }
}
