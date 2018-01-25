using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Exercise_1.Controllers;

namespace Exercise_1
{
    [Activity(Label = "Exercise_1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.tvLogin)] private TextView tvLogin;

        [InjectView(Resource.Id.tvPassword)] private TextView tvPassword;

        [InjectOnClick(Resource.Id.btnLogin)]
        private void Login(object sender, EventArgs e)
        {
            var tweetController = new TweetController();
            var cookie = tweetController.Login(tvLogin.Text, tvPassword.Text);
            if (cookie != null)
            {
                var intent = new Intent(this, typeof(LogoutActivity));
                intent.PutExtra("Cookie", cookie);
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Login failed. Try again!!!", ToastLength.Short).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
        }
    }
}

