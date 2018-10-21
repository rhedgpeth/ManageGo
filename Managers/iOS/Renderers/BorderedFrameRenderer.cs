using ManageGo.Controls;
using ManageGo.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderedFrame), typeof(BorderedFrameRenderer))]
namespace ManageGo.iOS.Renderers
{
    public class BorderedFrameRenderer : VisualElementRenderer<Frame>
    {
        public BorderedFrameRenderer()
        {
			Layer.CornerRadius = 5;
			Layer.BorderColor = UIColor.FromRGB(223, 223, 224).CGColor;         
            Layer.BorderWidth = 1;
        }
    }
}