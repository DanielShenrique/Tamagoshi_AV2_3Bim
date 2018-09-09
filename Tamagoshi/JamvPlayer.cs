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

		private Bitmap jamvStatus;

		private Paint color;

		private float width, height;

		public JamvPlayer(Bitmap images, Context c)
		{
			context = c;

			width = 5f;
			height = 5f;

			jamvStatus = images;

			color = new Paint();
			color.SetARGB(255, 255, 255, 255);
		}

		public void DrawnImage(Canvas canvas)
		{
			canvas.DrawBitmap(jamvStatus, width, height, color);
		}
	}
}