using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace Tamagoshi
{
	class GameView: View, IRunnable
	{
		Context context;

		private Paint color;

		private static bool isDead;

		private JamvPlayer jamvPlayer;

		public GameView(Context context) : base(context)
		{
			Initialize(context);
		}

		public GameView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			Initialize(context);
		}

		public GameView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
			Initialize(context);
		}

		private void Initialize(Context c)
		{

			context = c;

			SetBackgroundColor(Color.White);


			color = new Paint();
			color.SetARGB(255,255,255,255);

			jamvPlayer = new JamvPlayer(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Imagem_Happy), context);
		}

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
			if (!isDead)
			{
				jamvPlayer.DrawnImage(canvas);
			}

		}

		private void Update()
		{

		}

		public void Run()
		{
			//Update();
		}
	}
}