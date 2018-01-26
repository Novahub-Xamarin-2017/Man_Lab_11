using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Exercise_2.Models;

namespace Exercise_2.Adapters
{
    public class UserViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvId)] private TextView tvId;

        [InjectView(Resource.Id.tvLogin)] private TextView tvLogin;

        [InjectView(Resource.Id.imgAvatar)] private ImageView imgAvatar;

        public User User
        {
            set
            {
                tvId.Text = value.Id.ToString();
                tvLogin.Text = value.Login;
                Glide.With(ItemView.Context).Load(value.AvatarUrl).Into(imgAvatar);
            }
        }

        public UserViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}