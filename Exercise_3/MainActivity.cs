using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_3.Adapters;
using Exercise_3.Models;
using Exercise_3.Services;
using SearchView = Android.Widget.SearchView;

namespace Exercise_3
{
    [Activity(Label = "Exercise_3", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvResults)] private RecyclerView rvResults;

        [InjectView(Resource.Id.svImage)] private SearchView searchView;

        private SearchResult searchResult;

        private ImageAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            rvResults.SetLayoutManager(new LinearLayoutManager(this));
            
            searchView.QueryTextSubmit += (s, e) =>
            {
                var gettyImageController = new GettyImageController();
                searchResult = gettyImageController.Search(searchView.Query);
                adapter = new ImageAdapter(searchResult);
                rvResults.SetAdapter(adapter);
            };
        }
    }
}

