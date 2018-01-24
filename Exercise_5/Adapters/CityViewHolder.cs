using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_5.Models;

namespace Exercise_5.Adapters
{
    public class CityViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvName)] private TextView tvName;

        [InjectView(Resource.Id.tvItems)] private TextView tvItems;

        public City City
        {
            set
            {
                tvName.Text = value.Name;
                tvItems.Text =
                    value.Currencies.Aggregate("", (current, currency) => current + currency.ToString() + "\n");
            }
        }

        public CityViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}