using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Controls;
using XF.iOS.Renderers;

[assembly: ExportRenderer(typeof(TintImage), typeof(TintImageRenderer))]
namespace XF.iOS.Renderers
{
	public class TintImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                SetTint();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(TintImage.TintColor))
            {
                SetTint();
            }
        }

        protected void SetTint()
        {
            var element = (TintImage)Element;

            if (element.TintColor == Color.Default)
            {
                if (Control.Image != null)
                {
                    Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                }
                Control.TintColor = null;
            }
            else
            {
                if (Control.Image != null)
                {
                    Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                }
                Control.TintColor = element.TintColor.ToUIColor();
            }
        }
    }
}
