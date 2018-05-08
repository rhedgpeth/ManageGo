using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using ChangeColorSwitchEffect = ManageGo.iOS.Effects.ChangeColorSwitchEffect;
using FormsSwitchEffect = ManageGo.Effects.ChangeColorSwitchEffect;

[assembly: ResolutionGroupName("ManageGo")]
[assembly: ExportEffect(typeof(ChangeColorSwitchEffect), "ChangeColorSwitchEffect")]
namespace ManageGo.iOS.Effects
{
	public class ChangeColorSwitchEffect : PlatformEffect
    {
        Color _trueColor;
        Color _falseColor;
        Color _thumbColor;

        protected override void OnAttached()
        {
			_trueColor = (Color)Element.GetValue(FormsSwitchEffect.TrueColorProperty);
			_falseColor = (Color)Element.GetValue(FormsSwitchEffect.FalseColorProperty);
			_thumbColor = (Color)Element.GetValue(FormsSwitchEffect.ThumbColorProperty);
         
            var switchControl = Control as UISwitch;

            if (switchControl != null)
            {
                switchControl.TintColor = UIColor.FromRGBA((nfloat)_falseColor.R,
                                                           (nfloat)_falseColor.G,
                                                           (nfloat)_falseColor.B,
                                                           0.75f);


				switchControl.BackgroundColor = UIColor.FromRGBA((nfloat)_falseColor.R,
                                                           (nfloat)_falseColor.G,
                                                           (nfloat)_falseColor.B,
                                                           0.75f);
				switchControl.Layer.CornerRadius = 16.0f;


                // see example code for caveat about changing background colour... 
                switchControl.OnTintColor = UIColor.FromRGBA((nfloat)_trueColor.R,
                                                             (nfloat)_trueColor.G,
                                                             (nfloat)_trueColor.B,
                                                             0.75f);
                /*                                             
                switchControl.ThumbTintColor = UIColor.FromRGBA((nfloat)_thumbColor.R,
                                                                (nfloat)_thumbColor.G,
                                                                (nfloat)_thumbColor.B,
                                                                1.0f); */
            }
        }

        protected override void OnDetached()
        { }
    }
}
