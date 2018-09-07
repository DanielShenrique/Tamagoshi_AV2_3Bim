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
		}

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
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