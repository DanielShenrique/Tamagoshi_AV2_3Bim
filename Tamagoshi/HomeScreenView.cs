using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace Tamagoshi
{
	class HomeScreenView : View
    {
        private Context context;

        private Bitmap image;
        private Paint color;

        private float x, y;

        public HomeScreenView(Context context) : base(context)
        {
            Initiate(context);
        }

        public HomeScreenView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initiate(context);
        }

        public HomeScreenView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initiate(context);
        }

        private void Initiate(Context c)
        {
            context = c;

            image = BitmapFactory.DecodeResource(Resources, Resource.Drawable.TelaDeInicio);

            x = 150;
            y = 300;

            color = new Paint();
            color.Color = Color.White;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawBitmap(image, x, y, color);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if(e.Action == MotionEventActions.Up)
            {
                Intent i = new Intent(context, typeof(GameActivity));
                context.StartActivity(i);
            }
            return true;
        }
    }
}