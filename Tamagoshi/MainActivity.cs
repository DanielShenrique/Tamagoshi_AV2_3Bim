﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Util;

namespace Tamagoshi
{
    [Activity(Label = "Tamagoshi", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            SetContentView(new HomeScreenView(this));

        }
    }
}

