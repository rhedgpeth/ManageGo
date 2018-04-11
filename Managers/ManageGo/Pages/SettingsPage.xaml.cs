﻿using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using Xamarin.Forms;

namespace ManageGo.Pages
{
    public partial class SettingsPage : BaseContentPage<SettingsViewModel>
    {
        public SettingsPage() : base(Color.White)
        {
            InitializeComponent();
        }
    }
}
