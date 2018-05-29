using System;
using Xamarin.Forms;

namespace XF.Controls
{
	public class PanBoxView : PanContentView
    {
		private BoxView boxView;

		public PanBoxView()
		{
			boxView = new BoxView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			Content = boxView;
        }
    }
}
