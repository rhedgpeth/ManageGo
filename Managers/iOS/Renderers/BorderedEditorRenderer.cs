using ManageGo.Controls;
using ManageGo.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderedEditor), typeof(BorderedEditorRenderer))]
namespace ManageGo.iOS.Renderers
{
    public class BorderedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 4;
                Control.Layer.BorderColor = UIColor.FromRGB(223, 223, 224).CGColor;
                Control.Layer.BorderWidth = 1;
            }
        }
    }
}