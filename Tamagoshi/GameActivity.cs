
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Tamagoshi
{
	class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

			SetContentView(new GameView(this));
        }

    }
}