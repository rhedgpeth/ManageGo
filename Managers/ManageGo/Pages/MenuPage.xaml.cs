using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
    public partial class MenuPage : BaseContentPage<MenuViewModel>
    {
        public MenuPage() : base(Color.White)
        {
            InitializeComponent();
        }
    }
}
