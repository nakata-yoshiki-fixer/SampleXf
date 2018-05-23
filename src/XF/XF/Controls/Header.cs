using System;
using Xamarin.Forms;

namespace XF.Controls
{
	public class Header : RelativeLayout
    {
		private BoxView bar;
		private Label title;
		private TintImage rightIcon;
		private TintImage leftIcon;

        public Header()
        {
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			HeightRequest = Constants.GetInstance().HeaderHeight;

            // ■Control
			bar = new BoxView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Constants.GetInstance().HeaderBaseColor,
			};

			title = new Label
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
				TextColor = Constants.GetInstance().HeaderSubColor,
				HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			};

			rightIcon = new TintImage
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = Constants.GetInstance().HeaderIconSize,
				HeightRequest = Constants.GetInstance().HeaderIconSize,
                TintColor = Constants.GetInstance().HeaderSubColor,
			};

			leftIcon = new TintImage
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = Constants.GetInstance().HeaderIconSize,
                HeightRequest = Constants.GetInstance().HeaderIconSize,
                TintColor = Constants.GetInstance().HeaderSubColor,
            };

            // ■Binding
			title.SetBinding(Label.TextProperty, "HeaderTitle");
			rightIcon.SetBinding(Image.SourceProperty, "HeaderRightIconSource");
			leftIcon.SetBinding(Image.SourceProperty, "HeaderLeftIconSource");

            // ■Layout
			Children.Add(bar,
						 Constraint.RelativeToParent(parent => parent.X),
						 Constraint.RelativeToParent(parent => parent.Y),
						 Constraint.RelativeToParent(parent => parent.Width),
						 Constraint.RelativeToParent(parent => parent.Height));

			Children.Add(title,
						 Constraint.RelativeToParent(parent => parent.X + Constants.GetInstance().HeaderIconSize),
						 Constraint.RelativeToParent(parent => parent.Height - 30),
			             Constraint.RelativeToParent(parent => parent.Width - Constants.GetInstance().HeaderIconSize * 2),
						 Constraint.Constant(30));
			
			Children.Add(rightIcon,
						 Constraint.RelativeToParent(parent => parent.Width - Constants.GetInstance().HeaderIconSize - 10),
						 Constraint.RelativeToParent(parent => parent.Height - Constants.GetInstance().HeaderIconSize - 10),
						 Constraint.Constant(Constants.GetInstance().HeaderIconSize),
						 Constraint.Constant(Constants.GetInstance().HeaderIconSize));

            Children.Add(leftIcon,
			             Constraint.RelativeToParent(parent => parent.X + 10),
			             Constraint.RelativeToParent(parent => parent.Height - Constants.GetInstance().HeaderIconSize - 10),
			             Constraint.Constant(Constants.GetInstance().HeaderIconSize),
                         Constraint.Constant(Constants.GetInstance().HeaderIconSize));

			// Gesture
			rightIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command((obj) =>
				{
					if (OnRightIconClick != null)
						OnRightIconClick.Execute(obj);
				})
			});

			leftIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command((obj) => 
				{
					if (OnLeftIconClick != null)
						OnLeftIconClick.Execute(obj);
				})
			});
        }

		// ■BindableProperty
		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(nameof(Title),
									typeof(string),
									typeof(Header),
									null,
									BindingMode.TwoWay);

		public static readonly BindableProperty RightIconSourceProperty =
			BindableProperty.Create(nameof(RightIconSource),
									typeof(ImageSource),
									typeof(Header),
									default(ImageSource),
			                        BindingMode.TwoWay);

		public static readonly BindableProperty LeftIconSourceProperty =
			BindableProperty.Create(nameof(LeftIconSource),
									typeof(ImageSource),
									typeof(Header),
									default(ImageSource),
									BindingMode.TwoWay);

		public static readonly BindableProperty OnRightIconClickProperty =
			BindableProperty.Create(nameof(OnRightIconClick),
									typeof(Command),
									typeof(Header),
									default(Command),
			                        BindingMode.TwoWay);

		public static readonly BindableProperty OnLeftIconClickProperty =
			BindableProperty.Create(nameof(OnLeftIconClick),
                                    typeof(Command),
                                    typeof(Header),
                                    default(Command),
                                    BindingMode.TwoWay);

        // ■BindableProperty Delegate
		private static void RightIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var header = bindable as Header;
            if(header != null)
			{
				header.rightIcon.TintColor = Constants.GetInstance().HeaderSubColor;
			}
		}
              
        // ■Property
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

        public ImageSource RightIconSource
		{
			get { return (ImageSource)GetValue(RightIconSourceProperty); }
            set { SetValue(RightIconSourceProperty, value); }
		}

		public ImageSource LeftIconSource
		{
			get { return (ImageSource)GetValue(LeftIconSourceProperty); }
			set { SetValue(LeftIconSourceProperty, value); }
		}

        public Command OnRightIconClick
		{
			get { return (Command)GetValue(OnRightIconClickProperty); }
			set { SetValue(OnRightIconClickProperty, value); }
		}

		public Command OnLeftIconClick
        {
			get { return (Command)GetValue(OnLeftIconClickProperty); }
			set { SetValue(OnLeftIconClickProperty, value); }
        }
    }
}
