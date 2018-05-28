using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace XF.Controls
{
	public class Footer : StackLayout
	{
		public Footer()
		{
			Orientation = StackOrientation.Horizontal;
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			Padding = new Thickness(0, 10);
			ItemTemplate = new DataTemplate(typeof(FooterItem));
			BackgroundColor = Constants.GetInstance().FooterBaseColor;

			// Binding
			this.SetBinding(ItemSourceProperty, "FooterItems");
			this.SetBinding(SelectedItemProperty, "FooterSelectedItem");
			this.SetBinding(SelectedIndexProperty, "FooterSelectedIndex");
		}

		// ■BindableProperty
		public static readonly BindableProperty ItemSourceProperty =
			BindableProperty.Create(nameof(ItemSource),
									typeof(IList),
									typeof(Footer),
									default(IList),
									BindingMode.TwoWay,
									propertyChanged: (bindable, oldValue, newValue) => ((Footer)bindable).ItemSourceChanged());

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create(nameof(SelectedItem),
									typeof(object),
									typeof(Footer),
									null,
									BindingMode.TwoWay,
									propertyChanged: (bindable, oldValue, newValue) => ((Footer)bindable).SelectedItemChanged());

		public static readonly BindableProperty SelectedIndexProperty =
			BindableProperty.Create(nameof(SelectedIndex),
									typeof(int),
									typeof(Footer),
									0,
									BindingMode.TwoWay);

		// ■Property
		public DataTemplate ItemTemplate { get; set; }

		public IList ItemSource
		{
			get { return (IList)GetValue(ItemSourceProperty); }
			set
			{
				SetValue(ItemSourceProperty, value);
				OnPropertyChanged("ItemSource");
			}
		}

		public object SelectedItem
		{
			get { return GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public int SelectedIndex
		{
			get { return (int)GetValue(SelectedIndexProperty); }
			set { SetValue(SelectedIndexProperty, value); }
		}

		// ■Method      
		private void ItemSourceChanged()
		{
			// Update View
			Children.Clear();
			foreach (var item in ItemSource)
			{
				var view = (View)ItemTemplate.CreateContent();
				var bindableObject = view as BindableObject;
				if (bindableObject != null)
					bindableObject.BindingContext = item;

				var fItem = item as FooterItemViewModel;
				if (fItem != null)
				{
					view.GestureRecognizers.Add(new TapGestureRecognizer
					{
						Command = new Command(() =>
						{
							SelectedItem = item;
							fItem.OnItemSelect.Execute(fItem.CommandParameter);
						}),
					});
				}
				Children.Add(view);
			}
		}

		private void SelectedItemChanged()
		{
			SelectedIndex = ItemSource.IndexOf(SelectedItem);
		}
	}

	public class FooterItemViewModel
	{
		public ImageSource IconSource { get; set; }
		public string Text { get; set; }
		public Command OnItemSelect { get; set; }
		public object CommandParameter { get; set; }
	}

	public class FooterItem : StackLayout
	{
		private TintImage icon;
		private Label label;

		public FooterItem()
		{
			Orientation = StackOrientation.Vertical;
			VerticalOptions = LayoutOptions.CenterAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Constants.GetInstance().FooterBaseColor;

			// ■Control
			icon = new TintImage
			{
				WidthRequest = 32,
				HeightRequest = 32,
				TintColor = Constants.GetInstance().FooterSubColor,
			};

			label = new Label
			{
				FontSize = 8,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Constants.GetInstance().FooterSubColor,
			};

			// ■Binding
			icon.SetBinding(Image.SourceProperty, "IconSource");
			label.SetBinding(Label.TextProperty, "Text");

			// ■Layout
			Children.Add(icon);
			Children.Add(label);
		}

		// ■BindableProperty
		public static readonly BindableProperty IconSourceProperty =
			BindableProperty.Create(nameof(IconSource),
									typeof(ImageSource),
									typeof(FooterItem),
									null,
									BindingMode.TwoWay);

		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(nameof(Text),
									typeof(string),
									typeof(FooterItem),
									null,
									BindingMode.TwoWay);

		// ■Property
		public ImageSource IconSource
		{
			get { return (ImageSource)GetValue(IconSourceProperty); }
			set { SetValue(IconSourceProperty, value); }
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
	}

	public interface IFooterViewModel
	{
		IList FooterItems { get; set; }
		object FooterSelectedItem { get; set; }
		int FooterSelectedIndex { get; set; }
	}
}
