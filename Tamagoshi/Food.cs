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
    class Food
    {
        Context context;

        public int numFood;

        public Food(Context c)
        {
            context = c;

            numFood = 100;
        }
    }
}