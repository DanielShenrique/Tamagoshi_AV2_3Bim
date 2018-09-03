﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Tamagoshi
{
    class HomeScreen : View
    {
        private Context context;

        private Bitmap image;
        private Paint color;

        public HomeScreen(Context context) : base(context)
        {
            Initiate(context);
        }

        public HomeScreen(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initiate(context);
        }

        public HomeScreen(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initiate(context);
        }

        private void Initiate(Context c)
        {
            context = c;

            image = BitmapFactory.DecodeResource(Resources, Resource.Drawable.TelaDeInicio);

            color = new Paint();
            color.Color = Color.White;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawBitmap(image, 0, 0, color);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {

            if(e.Action == MotionEventActions.Up)
            {
                Intent i = new Intent(context, typeof(BackGame));
                context.StartActivity(i);
            }

            return true;
        }
    }
}