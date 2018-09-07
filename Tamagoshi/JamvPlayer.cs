using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tamagoshi
{
	class JamvPlayer
	{
		Context context;

		private Bitmap[] jamvStatus;


		public JamvPlayer(Bitmap[] images, Context c)
		{
			context = c;

			jamvStatus = images;
		}
	}
}