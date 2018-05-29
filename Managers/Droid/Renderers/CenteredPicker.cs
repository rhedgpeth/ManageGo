using Android.Views;
using ManageGo.Controls;
using ManageGo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CenteredPicker), typeof(CenteredPickerRenderer))]
namespace ManageGo.Droid.Renderers
{
    public class CenteredPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Gravity = GravityFlags.CenterHorizontal;
            }
        }
    }
}