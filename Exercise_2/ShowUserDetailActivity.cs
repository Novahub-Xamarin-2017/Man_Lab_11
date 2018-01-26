using Android.App;
using Android.OS;
using Android.Widget;
using Exercise_2.Controllers;

namespace Exercise_2
{
    [Activity(Label = "ShowUserDetailActivity")]
    public class ShowUserDetailActivity : Activity
    {
        [InjectView(Resource.Id.tvDetail)] private TextView tvDetail;

        [InjectView(Resource.Id.lvRepos)] private ListView lvRepos;

        private string login;

        private GithubApiServices services;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_show_detail);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            login = Intent.GetStringExtra("Login");
            services = new GithubApiServices();
            tvDetail.Text = services.GetUserDetail(login).ToString();
            lvRepos.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1,
                services.GetUserReposList(login));
        }
    }
}