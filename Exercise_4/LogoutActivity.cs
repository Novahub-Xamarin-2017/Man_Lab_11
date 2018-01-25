using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Exercise_1.Adapters;
using Exercise_1.Controllers;
using Exercise_1.Models;

namespace Exercise_1
{
    [Activity(Label = "LogoutActivity")]
    public class LogoutActivity : Activity
    {
        private readonly TweetController tweetController = new TweetController();

        private string cookie;

        private List<Tweet> tweets;

        private TweetAdapter adapter;

        [InjectView(Resource.Id.rvTweets)] private RecyclerView rvTweets;

        [InjectOnClick(Resource.Id.btnLogout)]
        private void Logout(object sender, EventArgs e)
        {
            if (!tweetController.Logout()) return;
            StartActivity(typeof(MainActivity));
        }

        [InjectOnClick(Resource.Id.btnGetTweets)]
        private void GetTweets(object sender, EventArgs e)
        {
            tweets = tweetController.Get(cookie);
            Log.Info("tweet", tweets[0].Id);
           adapter = new TweetAdapter(tweets);
            rvTweets.SetAdapter(adapter);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Logout);
            Cheeseknife.Inject(this);
            cookie = Intent.GetStringExtra("Cookie");
            rvTweets.SetLayoutManager(new LinearLayoutManager(this));
        }
    }
}