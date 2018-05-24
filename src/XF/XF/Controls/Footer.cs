using System;
using System.Collections;
using Xamarin.Forms;

namespace XF.Controls
{
	public class Footer : RelativeLayout
    {
		private BoxView bar;
		private int selectedIndex = -1;

        public Footer()
        {
			VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            HeightRequest = Constants.GetInstance().FooterHeight;
        }

		// ■BindableProperty
		public static readonly BindableProperty ItemsourceProperty =
			BindableProperty.Create(nameof(ItemSource),
									typeof(IList),
									typeof(Footer),
									default(IList),
									BindingMode.TwoWay);

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create(nameof(SelectedItem),
									typeof(object),
									typeof(Footer),
									null,
									BindingMode.TwoWay,
			                        propertyChanged: (bindable, oldValue, newValue) => ((Footer)bindable).SelectedItemChanged());

        // ■Property
        public IList ItemSource
		{
			get { return (IList)GetValue(ItemsourceProperty); }
			set { SetValue(ItemsourceProperty, value); }
		}

        public object SelectedItem
		{
			get { return GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

        // ■Method
        private void SelectedItemChanged()
        {
			
		}
    }

	public class FooterItemViewModel : ViewModels.BaseViewModel
    {
		public string IconSource { get; set; }
		public string Text { get; set; }
    }

	public class FootreCell : StackLayout
	{
		
	}
}
