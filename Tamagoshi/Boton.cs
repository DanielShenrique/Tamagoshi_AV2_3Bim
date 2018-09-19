using System;
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
    class Boton
    {
        Context context;

        private Bitmap Botao;

        private Paint color;
        public bool Cliquei;

        private float x, y;

        public Boton(Bitmap images, Context c, int newX, int newY)
        {
            context = c;

            x = newX;
            y = newY;

            Botao = images;

            color = new Paint();
            color.SetARGB(255, 255, 255, 255);
        }

        public void DrawnImage(Canvas canvas)
        {
            canvas.DrawBitmap(Botao, x, y, color);            
        }

        public bool DetectTouch(MotionEvent e)
        {
            if (e.RawX > x && e.RawY > y)
            {
                Log.Debug("Show", "DETECTEIIIIIIIIII");
                return true;
            }
            else return false;

        }


        public void Update()
        {
            
        }
    }
}