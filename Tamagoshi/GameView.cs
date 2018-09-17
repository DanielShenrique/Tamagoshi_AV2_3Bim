using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Tamagoshi
{
    class GameView: View, IRunnable, IServiceConnection
	{

        private CountBinder binder;
        private Count count;
        private bool isConnected;

		Context context;

		private Paint color;

		public static bool isDead;

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

            isConnected = false;
            binder = null;

            //BindService(new Intent(context, typeof(CountService)), this, Bind.AutoCreate);
            Toast.MakeText(context, "Bind Service", ToastLength.Short).Show();

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
            if (!isDead)
            {
                //jamvPlayer.jamvStatus
            }
		}


        public void Run()
        {
            Update();
        }

        private void UnbindConnection()
        {
            if (binder != null)
            {
                binder = null;
                count = null;
                context.UnbindService(this);
                Toast.MakeText(this.context, "Unbind Service", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this.context, "Service is already unbind", ToastLength.Short).Show();
            }
        }


        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            binder = (CountBinder)service;

            isConnected = binder != null;

            if (isConnected)
            {
                //count = binder.Service;
                Toast.MakeText(this.context, "Service Connected", ToastLength.Short).Show();
            }
            else
            {
                count = null;
                Toast.MakeText(this.context, "Service Not Connected", ToastLength.Short).Show();
            }
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            count = null;
            binder = null;
            isConnected = false;

            Toast.MakeText(this.context, "Service Disconnected", ToastLength.Short).Show();
        }
    }
}