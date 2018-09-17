using Android.Content;
using Android.Graphics;

namespace Tamagoshi
{
    class JamvPlayer
	{
		Context context;

		public Bitmap jamvStatus;

		private Paint color;

		private float x, y;

		public JamvPlayer(Bitmap images, Context c)
		{
			context = c;

            x = 0f;
            y = 0f;

			jamvStatus = images;

			color = new Paint();
			color.SetARGB(255, 255, 255, 255);
		}

		public void DrawnImage(Canvas canvas)
		{
			canvas.DrawBitmap(jamvStatus, x, y, color);
		}
	}
}