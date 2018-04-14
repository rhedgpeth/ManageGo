using System;
using ManageGo.Core.ViewModels;
using Xamarin.Forms;

namespace ManageGo.DataTemplates.ViewCells
{
	public class BaseSectionHeaderCell<T> : ViewCell where T : BaseCollectionSectionViewModel
    {
        public BaseSectionHeaderCell()
        { }
        
        /*
		protected override void OnTapped()
        {
            base.OnTapped();
            
            try
            {
                var section = (T)BindingContext;
            
                if (section.IsExpanded)
                {
                    IndicatorImage.RotateTo(-90);
                }
                else
                {
                    IndicatorImage.RotateTo(90);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }*/
    }
}

