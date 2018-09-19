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

        Handler handler;


        Context context;
        Intent i;

        private Paint color;
        private Paint textPaint;

        public static bool isDead;

		private JamvPlayer jamvPlayer;
        private Boton BotaoComida;
        private Boton BotaoAgua;

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

            i = new Intent(context, typeof(CountService));

            context.StartService(i);

            context.BindService(i, this, Bind.AutoCreate);
            Toast.MakeText(context, "Bind Service", ToastLength.Short).Show();

            SetBackgroundColor(Color.White);

			color = new Paint();
			color.SetARGB(255,255,255,255);
            textPaint = new Paint();
            textPaint.TextSize = 90;
            textPaint.SetARGB(50, 50, 50, 50);

            jamvPlayer = new JamvPlayer(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Imagem_Happy), context);
            BotaoComida = new Boton(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Steak), context, 50, 500);
            BotaoAgua = new Boton(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Agua), context, 300, 439);
            handler = new Handler();
            handler.Post(this);
        }

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
            BotaoComida.DrawnImage(canvas);
            BotaoAgua.DrawnImage(canvas);
            canvas.DrawText(count.Food().ToString(), 50, 900, textPaint);
            canvas.DrawText(count.Water().ToString(), 400, 900, textPaint);
            //count.Water();
            //count.Food();

            if (!isDead)
			{
				jamvPlayer.DrawnImage(canvas);
			}

		}
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if (BotaoComida.DetectTouch(e))
                {
                    count.SetFooD(5);
                    Toast.MakeText(context, "No alimento", ToastLength.Short).Show();
                }
            }
            return true;
        }

        private void Update()
		{
            if (!isDead)
            {
                //jamvPlayer.jamvStatus
                if (count != null)
                {
                    if (count.Food() <= 50 && count.Water() <= 50)
                    {
                        jamvPlayer.jamvStatus = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Imagem_Happy);
                    }
                }
            }
		}


        public void Run()
        {
                handler.PostDelayed(this, 30);

                Update();
                this.Invalidate();
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
                count = (Count)binder.Service;
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