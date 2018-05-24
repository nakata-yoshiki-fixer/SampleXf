using System;
using Xamarin.Forms;

namespace XF.Controls
{
	public class Header : RelativeLayout
    {
		private BoxView bar;
		private Label title;
		private TintImage rIcon;
		private TintImage lIcon;

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

			rIcon = new TintImage
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = Constants.GetInstance().HeaderIconSize,
				HeightRequest = Constants.GetInstance().HeaderIconSize,
                TintColor = Constants.GetInstance().HeaderSubColor,
			};

			lIcon = new TintImage
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = Constants.GetInstance().HeaderIconSize,
                HeightRequest = Constants.GetInstance().HeaderIconSize,
                TintColor = Constants.GetInstance().HeaderSubColor,
            };

            // ■Binding
			title.SetBinding(Label.TextProperty, "HeaderTitle");
			rIcon.SetBinding(Image.SourceProperty, "HeaderRightIconSource");
			lIcon.SetBinding(Image.SourceProperty, "HeaderLeftIconSource");

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
			
			Children.Add(rIcon,
						 Constraint.RelativeToParent(parent => parent.Width - Constants.GetInstance().HeaderIconSize - 10),
						 Constraint.RelativeToParent(parent => parent.Height - Constants.GetInstance().HeaderIconSize - 10),
						 Constraint.Constant(Constants.GetInstance().HeaderIconSize),
						 Constraint.Constant(Constants.GetInstance().HeaderIconSize));

            Children.Add(lIcon,
			             Constraint.RelativeToParent(parent => parent.X + 10),
			             Constraint.RelativeToParent(parent => parent.Height - Constants.GetInstance().HeaderIconSize - 10),
			             Constraint.Constant(Constants.GetInstance().HeaderIconSize),
                         Constraint.Constant(Constants.GetInstance().HeaderIconSize));

			// ■Gesture
			rIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command((obj) =>
				{
					if (OnRIconClick != null)
						OnRIconClick.Execute(obj);
				})
			});

			lIcon.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command((obj) => 
				{
					if (OnLIconClick != null)
						OnLIconClick.Execute(obj);
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

		public static readonly BindableProperty RIconSourceProperty =
			BindableProperty.Create(nameof(RIconSource),
									typeof(ImageSource),
									typeof(Header),
									default(ImageSource),
			                        BindingMode.TwoWay);

		public static readonly BindableProperty LIconSourceProperty =
			BindableProperty.Create(nameof(LIconSource),
									typeof(ImageSource),
									typeof(Header),
									default(ImageSource),
									BindingMode.TwoWay);

		public static readonly BindableProperty OnRIconClickProperty =
			BindableProperty.Create(nameof(OnRIconClick),
			                        typeof(Command),
									typeof(Header),
			                        default(Command),
			                        BindingMode.TwoWay);

		public static readonly BindableProperty OnLIconClickProperty =
			BindableProperty.Create(nameof(OnLIconClick),
			                        typeof(Command),
                                    typeof(Header),
			                        default(Command),
                                    BindingMode.TwoWay);

        // ■BindableProperty Delegate
              
        // ■Property
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public ImageSource RIconSource
		{
			get { return (ImageSource)GetValue(RIconSourceProperty); }
            set { SetValue(RIconSourceProperty, value); }
		}

		public ImageSource LIconSource
		{
			get { return (ImageSource)GetValue(LIconSourceProperty); }
			set { SetValue(LIconSourceProperty, value); }
		}
        
		public Command OnRIconClick
		{
			get { return (Command)GetValue(OnRIconClickProperty); }
			set { SetValue(OnRIconClickProperty, value); }
		}

		public Command OnLIconClick
        {
			get { return (Command)GetValue(OnLIconClickProperty); }
			set { SetValue(OnLIconClickProperty, value); }
        }
    }
}
