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
    class CountBinder : Binder
    {
        public CountBinder(CountService service)
        {
            this.Service = service;
        }

        public CountService Service { get; private set; }
    }    
}