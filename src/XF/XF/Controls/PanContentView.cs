using System;
using Xamarin.Forms;

namespace XF.Controls
{
	public class PanContentView : ContentView
	{
		private PanGestureRecognizer panGesture;

        public PanContentView()
		{
			panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += PanUpdated;
			GestureRecognizers.Add(panGesture);
		}

		// ■BindableProperty
		public static readonly BindableProperty StartXProperty =
			BindableProperty.Create(nameof(StartX),
									typeof(double),
									typeof(PanContentView),
									0.0,
									BindingMode.TwoWay);

		public static readonly BindableProperty StartYProperty =
			BindableProperty.Create(nameof(StartY),
									typeof(double),
									typeof(PanContentView),
									0.0,
									BindingMode.TwoWay);

		public static readonly BindableProperty EndXProperty =
			BindableProperty.Create(nameof(EndX),
									typeof(double),
									typeof(PanContentView),
									0.0,
									BindingMode.TwoWay);

		public static readonly BindableProperty EndYProperty =
			BindableProperty.Create(nameof(EndY),
									typeof(double),
									typeof(PanContentView),
									0.0,
									BindingMode.TwoWay);

		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create(nameof(Command),
									typeof(Command),
									typeof(PanContentView),
									default(Command),
									BindingMode.TwoWay,
									propertyChanged: (bindable, oldValue, newValue) => ((PanContentView)bindable).CommandUpdate());

		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create(nameof(CommandParameter),
									typeof(object),
									typeof(PanContentView),
									null,
									BindingMode.TwoWay,
									propertyChanged: (bindable, oldValue, newValue) => ((PanContentView)bindable).CommandUpdate());

		// ■Property
		public double StartX
		{
			get { return (double)GetValue(StartXProperty); }
			set { SetValue(StartXProperty, value); }
		}

		public double StartY
		{
			get { return (double)GetValue(StartYProperty); }
			set { SetValue(StartYProperty, value); }
		}

		public double EndX
		{
			get { return (double)GetValue(EndXProperty); }
			set { SetValue(EndXProperty, value); }
		}

		public double EndY
		{
			get { return (double)GetValue(EndYProperty); }
			set { SetValue(EndYProperty, value); }
		}

		public Command Command
		{
			get { return (Command)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		// ■Method
		private void CommandUpdate()
		{
			panGesture = new PanGestureRecognizer();
			panGesture.PanUpdated += (sender, e) =>
			{
				Command.Execute(CommandParameter);
			};
			Content.GestureRecognizers.Add(panGesture);
		}

		private void PanUpdated(object sender, PanUpdatedEventArgs e)
		{
			switch (e.StatusType)
			{
				case GestureStatus.Started:
					StartX = e.TotalX;
					StartY = e.TotalY;
					break;
				case GestureStatus.Running:
					EndX = e.TotalX;
					EndY = e.TotalY;
					break;
				default:
					break;
			}
		}
	}
}
