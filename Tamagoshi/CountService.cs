﻿
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Java.Lang;

namespace Tamagoshi
{
    [Service(Name = "com.Tamagoshi.CountService")]
    class CountService : Service, IRunnable, Count
    {
        public int foodCount;
        protected int waterCount;

        private bool active;

        private Handler h;

        public IBinder Binder { get; private set; }


        public override void OnCreate()
        {
            base.OnCreate();

            foodCount = 100;
            waterCount = 100;

            active = true;

            h = new Handler();
            h.Post(this);

        }

        public override IBinder OnBind(Intent intent)
        {
            this.Binder = new CountBinder(this);
            return this.Binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            return base.OnUnbind(intent);
        }

        public override void OnDestroy()
        {
            Binder = null;
            active = false;

            base.OnDestroy();
        }

        #region função de pegar a agua e a comida
        public int Water()
        {
            return waterCount;
        }
        public int Food()
        {
            return foodCount;
        }
        public void SetWateR(int value)
        {
            if (waterCount + value < 100)
                waterCount += value;

            else
                waterCount = 100;
        }
        public void SetFooD(int value)
        {
            if (foodCount + value < 100)
                foodCount += value;

            else
                foodCount = 100;
            if(foodCount + value > 0)
            {
                foodCount = 0;
            }
        }
        #endregion

        public void Run()
        {
            if (active)
            {
                waterCount--;
                foodCount--;

                h.PostDelayed(this, 1000);
            }
            else
            {
                waterCount = 0;
                foodCount = 0;

                StopSelf();
            }
        }
    }
}