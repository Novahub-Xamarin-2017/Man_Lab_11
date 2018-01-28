using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Exercise_1.Models;

namespace Exercise_1.Adapters
{
    public class TweetViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvId)] private TextView tvId;

        [InjectView(Resource.Id.tvAuthor)] private TextView tvAuthor;

        [InjectView(Resource.Id.tvContent)] private TextView tvContent;

        [InjectView(Resource.Id.imgTweet)] private ImageView imgTweet;

        public Tweet Tweet
        {
            set
            {
                tvId.Text = value.Id;
                tvAuthor.Text = value.Author;
                tvContent.Text = value.Content;
                if (value.Images == null) return;
                Glide.With(ItemView.Context).Load((value.Images[0])).Into(imgTweet);
            }
        }

        public TweetViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}