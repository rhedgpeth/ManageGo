using Android.Content;
using ManageGo.Controls;
using Xamarin.Forms;
using ManageGo.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderedEditor), typeof(BorderedEditorRenderer))]

namespace ManageGo.Droid
{
    public class BorderedEditorRenderer : EditorRenderer
    {
        public BorderedEditorRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.grey_rect));
        }
    }
}