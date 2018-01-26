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

            // Set our view from the "main" layout resource
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
                listUser = service.SeachUsers(svUsers.Query);
                adapter = new UserAdapter(listUser);
                rvResults.SetAdapter(adapter);
            };
        }
    }
}

