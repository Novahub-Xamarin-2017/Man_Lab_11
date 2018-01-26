using Android.Views;

namespace Exercise_2.Interfaces
{
    public interface IItemClickListener
    {
        void OnClick(View itemView, int position);
    }
}