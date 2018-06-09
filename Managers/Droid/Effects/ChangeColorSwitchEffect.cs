﻿using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Color = Xamarin.Forms.Color;
using Switch = Android.Widget.Switch;

using ChangeColorSwitchEffect = ManageGo.Droid.Effects.ChangeColorSwitchEffect;
using FormsSwitchEffect = ManageGo.Effects.ChangeColorSwitchEffect;

[assembly: ResolutionGroupName("ManageGo")]
[assembly: ExportEffect(typeof(ChangeColorSwitchEffect), "ChangeColorSwitchEffect")]

namespace ManageGo.Droid.Effects
{
    /// <summary>
    /// Based on the samples at https://github.com/FormsCommunityToolkit/Effects
    /// and  http://stackoverflow.com/questions/11253512/change-on-color-of-a-switch
    /// </summary>
    [Android.Runtime.Preserve(AllMembers = true)]
    public class ChangeColorSwitchEffect : PlatformEffect
    {
        private Color _trueColor;
        private Color _falseColor;
        private Color _thumbColor;

        // slightly darker for the tracks, otherwise there's no virtual
        // 'depth' below the 'thumb' part of the slider.
        private Color _falseColorDarker;
        private Color _trueColorDarker;

        protected override void OnAttached()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                _thumbColor = (Color)Element.GetValue(FormsSwitchEffect.ThumbColorProperty);
				_trueColor = (Color)Element.GetValue(FormsSwitchEffect.TrueColorProperty);
				_falseColor = (Color)Element.GetValue(FormsSwitchEffect.FalseColorProperty);

				_falseColorDarker = _falseColor.AddLuminosity(-0.15);
                _trueColorDarker = _trueColor.AddLuminosity(-0.15);

                ((SwitchCompat)Control).CheckedChange += OnCheckedChange;

                ((SwitchCompat)Control).TrackDrawable.SetColorFilter(_falseColorDarker.ToAndroid(), PorterDuff.Mode.Multiply);

                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_thumbColor.ToAndroid(), PorterDuff.Mode.Multiply);
                // to change the colour of the thumb-drawable to the 'true' (or 'false') colour, enable the line below (and disable the one above)
                // ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_trueColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
        }

        void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs checkedChangeEventArgs)
        {
            if (checkedChangeEventArgs.IsChecked)
            {
                ((SwitchCompat)Control).TrackDrawable.SetColorFilter(_trueColorDarker.ToAndroid(), PorterDuff.Mode.Multiply);
                // to change the colour of the thumb-drawable to the 'true' (or false) colour, enable the line below
                // ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_trueColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
            else
            {
                ((SwitchCompat)Control).TrackDrawable.SetColorFilter(_falseColorDarker.ToAndroid(), PorterDuff.Mode.Multiply);
                // to change the colour of the thumb-drawable to the 'true' (or false) colour, enable the line below
                // ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_thumbColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
        }

        protected override void OnDetached()
        {
			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean 
			    && Control is Switch control)
            {  
				control.CheckedChange -= OnCheckedChange;
			}
        }
    }
}