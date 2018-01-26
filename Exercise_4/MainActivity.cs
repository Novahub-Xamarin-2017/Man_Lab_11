using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Exercise_4.Controllers;

namespace Exercise_4
{
    [Activity(Label = "Exercise_4", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.tvWeatherInfo)] private TextView tvWeatherInfo;

        [InjectView(Resource.Id.svCityName)] private SearchView svCityName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            svCityName.QueryTextSubmit += (s, e) =>
            {
                var service = new OpenWeatherMapServices();
                var weatherInfo = service.GetWeatherByCityName(svCityName.Query);
                if (weatherInfo != null)
                    tvWeatherInfo.Text = weatherInfo.ToString();
                else
                    Toast.MakeText(this, "Invalid city, try again!", ToastLength.Short).Show();
            };
        }
    }
}

