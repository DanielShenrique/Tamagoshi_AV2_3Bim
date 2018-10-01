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
        CountService FoodCount;
        private bool isConnected;

        Handler handler;


        Context context;
        Intent i;

        private Paint color;
        private Paint textPaint;

        public static bool isDead;

		private JamvPlayer jamvPlayer;
        JamvPlayer jamvPlayerHalfandHalf;
        JamvPlayer JanvMorreu;
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
            isDead = false;

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
            jamvPlayerHalfandHalf = new JamvPlayer(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Imagem_MeioAMeio), context);
            JanvMorreu = new JamvPlayer(BitmapFactory.DecodeResource(Resources, Resource.Drawable.KO), context);
            BotaoComida = new Boton(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Steak), context, 50, 500, 200,200);
            BotaoAgua = new Boton(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Agua), context, 300, 439,300,300);
            handler = new Handler();
            FoodCount = new CountService();
            handler.Post(this);
        }

		protected override void OnDraw(Canvas canvas)
		{
			base.OnDraw(canvas);
            BotaoComida.DrawnImage(canvas);
            BotaoAgua.DrawnImage(canvas);
            canvas.DrawText(count.Food().ToString(), 50, 900, textPaint);
            canvas.DrawText(count.Water().ToString(), 400, 900, textPaint);

            if (!isDead)
            {
                //jamvPlayer.jamvStatus
                if (count != null)
                {
                    if (count.Food() >50 || count.Water() > 50)
                    {
                        jamvPlayer.DrawnImage(canvas);
                    }
                    if (count.Food() < 50 || count.Water() < 50)
                    {
                        jamvPlayerHalfandHalf.DrawnImage(canvas);
                    }
                }
            }
            if (count.Food() < 0 || count.Water() < 0)
            {
                isDead = true;
                JanvMorreu.DrawnImage(canvas);
            }

		}

        public override bool OnTouchEvent(MotionEvent e)
        {
            
            if (e.Action == MotionEventActions.Up)
            {
                if (DetectTouchFood(e.GetX(), e.GetY()))
                {
                    Log.Debug("UP", "TOKKKKKK");
                    count.SetFooD(5);
                }
                if (DetectTouchWater(e.GetX(), e.GetY()))
                {
                    count.SetWateR(5);
                }
            }
            return true;
        }

        private bool DetectTouchFood(float x, float y)
        {          
            if (x > BotaoComida.x && x < BotaoComida.x + BotaoComida.w && y > BotaoComida.y && y < BotaoComida.y + BotaoComida.h)
            {
                Toast.MakeText(context, "No alimento", ToastLength.Short).Show();
                return true;
            }
            else return false;
        }

        private bool DetectTouchWater(float x,float y)
        {
            if (x > BotaoAgua.x && x < BotaoAgua.x + BotaoAgua.w && y > BotaoAgua.y && y < BotaoAgua.y + BotaoAgua.h)
            {
                Toast.MakeText(context, "Na Agua", ToastLength.Short).Show();
                return true;
            }
            else return false;
        }

        public void Run()
        {
                handler.PostDelayed(this, 30);

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