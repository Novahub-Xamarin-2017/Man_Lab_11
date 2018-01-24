using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_6.Models;

namespace Exercise_6.Adapter
{
    public class CurrencyViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvName)] private TextView tvName;

        [InjectView(Resource.Id.tvCode)] private TextView tvCode;

        [InjectView(Resource.Id.tvBuy)] private TextView tvBuy;

        [InjectView(Resource.Id.tvTransfer)] private TextView tvTransfer;

        [InjectView(Resource.Id.tvSell)] private TextView tvSell;

        public Currency Currency
        {
            set
            {
                tvName.Text = value.Name;
                tvCode.Text = value.Code;
                tvBuy.Text = value.Buy;
                tvTransfer.Text = value.Transfer;
                tvSell.Text = value.Sell;
            }
        }

        public CurrencyViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}