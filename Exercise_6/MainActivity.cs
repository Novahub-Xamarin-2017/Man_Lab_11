using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Exercise_6.Adapter;
using Exercise_6.Interfaces;
using Exercise_6.Models;
using Refit;

namespace Exercise_6
{
    [Activity(Label = "Exercise_6", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.tvDateTime)] private TextView tvDateTime;

        [InjectView(Resource.Id.rvCurrencies)] private RecyclerView rvCurrencies;

        [InjectView(Resource.Id.tvSource)] private TextView tvSource;

        private CurrencyAdapter currencyAdapter;

        private CurrencyList currencyList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            Init();
        }

        private static async Task<string> GetData()
        {
            var vietcombankService = RestService.For<IVietcombank>("https://www.vietcombank.com.vn");
            var result =  await vietcombankService.GetCurrencies();
            Log.Info("Result", result);
            return result;
        }

        private static CurrencyList ConvertXmlToObject(string data)
        {
            var serializer = new XmlSerializer(typeof(CurrencyList));
            using (var reader = new StringReader(data))
            {
                return (CurrencyList) serializer.Deserialize(reader);
            }
        }

        private async void Init()
        {
            rvCurrencies.SetLayoutManager(new LinearLayoutManager(this));
            var data = await GetData();
            currencyList = ConvertXmlToObject(data);
            currencyAdapter = new CurrencyAdapter(currencyList);
            rvCurrencies.SetAdapter(currencyAdapter);
            tvDateTime.Text = currencyList.DateTime;
            tvSource.Text = currencyList.Source;
        }
    }
}

