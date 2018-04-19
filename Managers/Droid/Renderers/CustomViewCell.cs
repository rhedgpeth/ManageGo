using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using View = Android.Views.View;
using ViewGroup = Android.Views.ViewGroup;
using Context = Android.Content.Context;
using ListView = Android.Widget.ListView;

using ManageGo.Droid.Renderers;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace ManageGo.Droid.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            if (parent is ListView)
            {
                ((ListView)parent).SetSelector(Resource.Color.Transparent);
                ((ListView)parent).CacheColorHint = Color.Transparent.ToAndroid();
            }

            return base.GetCellCore(item, convertView, parent, context);
        }
    }
}
