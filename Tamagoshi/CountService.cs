
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
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
        private bool reciveMensage;

        private Handler h;

        public IBinder Binder { get; private set; }


        public override void OnCreate()
        {
            base.OnCreate();

            foodCount = 100;
            waterCount = 100;

            active = true;
            reciveMensage = false;

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

        void Notification(int resource)
        {

            Intent resultIntent = new Intent(this, typeof(MainActivity));

            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
            string myTitle, myContent;

            if(resource == 0)
            {
                myTitle = "Need Water";
                myContent = "JKASDFIDOAJISODJIOAJISODJIOASJIODJBJABI  OIAH QIOS";
            }
            else if(resource == 1)
            {
                myTitle = "Need food";
                myContent = "JKASDFIDOAJISODJIOAJISODJIOASJIODJBJABI  OIAH QIOS";
            }
            else
            {
                myTitle = "Morreu";
                myContent = "JKASDFIDOAJISODJIOAJISODJIOASJIODJBJABI  OIAH QIOS";
            }

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
               .SetAutoCancel(true)
               .SetDefaults((int)NotificationDefaults.Sound)
               .SetContentIntent(resultPendingIntent)
               .SetContentTitle(myTitle)
               .SetContentText(myContent);

            NotificationManager nf = (NotificationManager)this.GetSystemService(Context.NotificationService);
            nf.Notify(1000, builder.Build());
        }

        public void Run()
        {
            if (active)
            {
                waterCount--;
                foodCount--;

                if (reciveMensage)
                {
                    if (waterCount <= 25)
                    {
                        Notification(0);
                        reciveMensage = true;
                    }

                    if (foodCount <= 25)
                    {
                        Notification(1);
                        reciveMensage = true;
                    }

                    if (waterCount == 0 || foodCount == 0)
                    {
                        Notification(2);
                        reciveMensage = true;
                    }
                }

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