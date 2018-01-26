using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_2.Interfaces;
using Exercise_2.Models;

namespace Exercise_2.Adapters
{
    public class UserAdapter : RecyclerView.Adapter, IItemClickListener
    {
        private readonly ListUser listUser;

        public UserAdapter(ListUser listUser)
        {
            this.listUser = listUser;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is UserViewHolder viewHolder)) return;
            viewHolder.User = listUser.Users[position];
            viewHolder.ItemClickListener = this;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.user_item, parent, false);
            return new UserViewHolder(itemView);
        }

        public override int ItemCount => listUser.TotalCount;

        public void OnClick(View itemView, int position)
        {
            var intent = new Intent(itemView.Context, typeof(ShowUserDetailActivity));
            intent.PutExtra("Login", listUser.Users[position].Login);
            itemView.Context.StartActivity(intent);
        }
    }
}