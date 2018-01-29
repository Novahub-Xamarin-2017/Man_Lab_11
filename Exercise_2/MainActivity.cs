using System;
using System.Net;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_2.Adapters;
using Exercise_2.Controllers;
using Exercise_2.Models;
using SearchView = Android.Widget.SearchView;

namespace Exercise_2
{
    [Activity(Label = "Exercise_2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvResults)] private RecyclerView rvResults;

        [InjectView(Resource.Id.svUsers)] private SearchView svUsers;

        private ListUser listUser;

        private UserAdapter adapter;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            rvResults.SetLayoutManager(new LinearLayoutManager(this));
            
            var service = new GithubApiServices();
            svUsers.QueryTextSubmit += (s, e) =>
            {
                try
                {
                    listUser = service.SeachUsers(svUsers.Query);
                }
                catch (WebException exception)
                {
                    Console.WriteLine(exception);
                    return;
                }
                if (adapter == null)
                    adapter = new UserAdapter(listUser);
                else
                    adapter.NotifyDataSetChanged();
                rvResults.SetAdapter(adapter);
            };
        }
    }
}

