using Android.Support.V7.Widget;
using Xamarin.Forms.Platform.Android;

namespace HymnPlayer.Droid.Extenstions
{
    public class BrownishSearchBar : PlatformEffect
    {
        protected override void OnAttached()
        {
            var searchBar = (SearchView) Control;
        }

        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}