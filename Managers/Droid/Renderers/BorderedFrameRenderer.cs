using Android.Content;
using FormsPlayground.Droid;
using ManageGo.Controls;
using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
using ManageGo.Droid;
using Android.Support.V7.Graphics.Drawable;

[assembly: ExportRenderer(typeof(BorderedFrame), typeof(BorderedFrameRenderer))]

namespace FormsPlayground.Droid
{
	public class BorderedFrameRenderer : Xamarin.Forms.Platform.Android.VisualElementRenderer<Frame>
	{      
		public BorderedFrameRenderer(Context context) : base(context)
		{

			SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.grey_rect));
		}
	}
}