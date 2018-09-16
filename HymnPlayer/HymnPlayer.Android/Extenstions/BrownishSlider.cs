using Android.Graphics;
using Android.Widget;
using HymnPlayer.Droid.Extenstions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ResolutionGroupName("CustomEffects")]
[assembly: ExportEffect(typeof(BrownishSlider), "BrownSliderEffect")]
namespace HymnPlayer.Droid.Extenstions
{
    public class BrownishSlider : PlatformEffect
    {
        protected override void OnAttached()
        {
            var seekBar = (SeekBar) Control;
            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Bisque.ToAndroid(), PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.SandyBrown.ToAndroid(), PorterDuff.Mode.SrcIn));
        }

        protected override void OnDetached()
        {
            // throw new System.NotImplementedException();
        }
    }
}