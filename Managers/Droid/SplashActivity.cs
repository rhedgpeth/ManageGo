﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ManageGo.Droid
{
	[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
		static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

		// Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();

			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
