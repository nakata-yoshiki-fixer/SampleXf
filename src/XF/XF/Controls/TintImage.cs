using System;
using Xamarin.Forms;

namespace XF.Controls
{
	public class TintImage : Image
    {
        public static readonly BindableProperty TintColorProperty =
			BindableProperty.Create(nameof(TintColor),
			                        typeof(Color),
			                        typeof(TintImage),
			                        default(Color),
			                        BindingMode.TwoWay);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
    }
}
