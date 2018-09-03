using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tamagoshi
{
    class BackGame : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            GetIntentMensage();
        }

        private void GetIntentMensage()
        {
            Intent i = Intent;

            if(i != null)
            {
                Bundle parameters = i.Extras;

                if(parameters != null)
                {
                    Toast.MakeText(this, parameters.GetString(Intent.ExtraText), ToastLength.Short).Show(); 
                }
            }
        }
    }
}