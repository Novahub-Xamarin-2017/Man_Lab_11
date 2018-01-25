using System.Net;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Exercise_3.Models;
using Square.Picasso;
using Uri = Android.Net.Uri;

namespace Exercise_3.Adapters
{
    public class ImageViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;

        [InjectView(Resource.Id.imgResult)] private ImageView imgResult;

        public Image Image
        {
            set
            {
                tvTitle.Text = value.Title;
                Picasso.With(ItemView.Context).Load(value.DisplaySizes[0].Uri).Into(imgResult);
            }
        }

        public ImageViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}