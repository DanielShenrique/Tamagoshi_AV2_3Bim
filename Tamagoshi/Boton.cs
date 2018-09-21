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

        public float x, y, w, h;

        public Boton(Bitmap images, Context c, int newX, int newY, int newW, int newH)
        {
            context = c;

            h = newH;
            w = newW;
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
        public void Update()
        {
            
        }
    }
}