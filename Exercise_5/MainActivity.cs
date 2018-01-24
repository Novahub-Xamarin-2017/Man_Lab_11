using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Exercise_5.Adapters;
using Exercise_5.Interfaces;
using Exercise_5.Models;
using Refit;

namespace Exercise_5
{
    [Activity(Label = "Exercise_5", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;

        [InjectView(Resource.Id.tvUrl)] private TextView tvUrl;

        [InjectView(Resource.Id.tvUpdatedTime)] private TextView tvUpdatedTime;

        [InjectView(Resource.Id.tvUnit)] private TextView tvUnit;

        [InjectView(Resource.Id.rvCities)] private RecyclerView rvCities;

        private SjcGoldRate sjcGoldRate;

        private CityAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            Init();
        }

        private static async Task<string> GetData()
        {
            var sjcService = RestService.For<ISjc>("http://www.sjc.com.vn");
            return await sjcService.Get();
        }

        private static SjcGoldRate ConvertXmlToObject(string data)
        {
            var serializer = new XmlSerializer(typeof(SjcGoldRate));
            using (var reader = new StringReader(data))
            {
                return (SjcGoldRate) serializer.Deserialize(reader);
            }
        }

        private async void Init()
        {
            sjcGoldRate = ConvertXmlToObject(await GetData());
            adapter = new CityAdapter(sjcGoldRate);
            rvCities.SetLayoutManager(new LinearLayoutManager(this));
            rvCities.SetAdapter(adapter);
            tvTitle.Text = sjcGoldRate.Title;
            tvUrl.Text = sjcGoldRate.Url;
            tvUpdatedTime.Text = sjcGoldRate.CityList.UpdatedTime;
            tvUnit.Text = sjcGoldRate.CityList.Unit;
        }
    }
}

