﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;

namespace ManageGo.Pages
{
    public partial class RegisterPage : BaseContentPage<RegisterViewModel>
    {
        public RegisterPage() : base(Color.White)
        {
            InitializeComponent();
        }
    }
}
