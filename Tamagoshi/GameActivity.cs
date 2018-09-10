
using Android.App;
using Android.OS;

namespace Tamagoshi
{
    [Activity(Label = "Tamagoshi")]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

			SetContentView(new GameView(this));
        }

    }
}