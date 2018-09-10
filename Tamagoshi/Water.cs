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
    class Water
    {
        Context context;

        public int numWater;

        public Water(Context c)
        {
            context = c;

            numWater = 100;
        }
    }
}