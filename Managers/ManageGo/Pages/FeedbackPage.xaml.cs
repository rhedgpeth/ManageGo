using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Pages;
using Xamarin.Forms;

namespace ManageGo.Pages
{
    public partial class FeedbackPage : BaseContentPage<FeedbackViewModel>
    {    
        public FeedbackPage()
        {
            InitializeComponent();         
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
        {
			await DisplayActionSheet("Pick an option", "Cancel", "Close", "General feedback", "Support");
        }      
	}
}
