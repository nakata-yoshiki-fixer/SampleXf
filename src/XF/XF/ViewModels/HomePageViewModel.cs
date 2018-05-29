using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Controls;
using XF.Logics;
using XF.Interfaces;

namespace XF.ViewModels
{
	public class HomePageViewModel : BaseViewModel, IHeaderViewModel, IFooterViewModel
	{
		public HomePageViewModel() : base("HomePageViewModel")
		{
			// ■Header
			HeaderTitle = "Home";
			HeaderRightIconSource = ImageSource.FromFile("Icon/setting.png");
			//HeaderLeftIconSource = ImageSource.FromFile("Icon/setting.png");

			HeaderRightCommand = new Command(() =>
			{
				Application.Current.MainPage.DisplayAlert("Setting", "", "OK");
			});

			HeaderLeftCommand = new Command(() =>
			{
			});

			// ■Footer
			FooterItems = new ObservableCollection<FooterItemViewModel>
			{
				new FooterItemViewModel
				{
					IconSource = "Icon/fingerprint.png",
					Text = "認証",
					OnItemSelect = new Command(() =>
					{
						var localAuthenticator = DependencyService.Get<ILocalAuthenticator>();
						if(localAuthenticator.CheckDevice())
						{
							Device.BeginInvokeOnMainThread(async() =>
							{
								var result = await localAuthenticator.AuthAsync();
								await DisplayDialogLogic.Alert("Authentication Result", result.ToString(), "OK");
							});
						}
					}),
				},
			};

			// ■MainImage

			// ■AlertButton
			AlertCommand = new Command(async () =>
			{
				await DisplayDialogLogic.Alert("Button Clicked", "SampleDialog", "OK");
				SampleText = "DisplayAlert OK";
			});

			// ■SampleLabel
			SampleText = "default";

			PanPoint = "(0.0, 0.0) => (0.0, 0.0)";
		}

		// Header
		public string HeaderTitle { get; set; }
		public ImageSource HeaderRightIconSource { get; set; }
		public ImageSource HeaderLeftIconSource { get; set; }
		public ICommand HeaderRightCommand { get; set; }
		public ICommand HeaderLeftCommand { get; set; }

		// Footer
		public IList FooterItems { get; set; }
		public object FooterSelectedItem { get; set; }
		public int FooterSelectedIndex { get; set; }

		// MainImage
		public Color MainImageColor { get; set; }
		public string MainImageSource { get; set; }
		public double MainImageX { get; set; }
		public double MainImageY { get; set; }
		public double MainImageZ { get; set; }

		// AlertButton
		public ICommand AlertCommand { get; set; }

		// SampleLabel
		private string sampleText;
		public string SampleText
		{
			get { return sampleText; }
			set
			{
				sampleText = value;
				OnPropertyChanged("SampleText");
			}
		}

		// PanBoxView
		private double boxViewStartX;
        public double BoxViewStartX
		{
			get { return boxViewStartX; }
			set
			{
				boxViewStartX = value;
				OnPropertyChanged("BoxViewStartX");
				PointUpdate();
			}
		}

		private double boxViewStartY;
        public double BoxViewStartY
        {
            get { return boxViewStartY; }
            set
            {
                boxViewStartY = value;
                OnPropertyChanged("BoxViewStartY");
				PointUpdate();
            }
        }

		private double boxViewEndX;
        public double BoxViewEndX
		{
			get { return boxViewEndX; }
			set
			{
				boxViewEndX = value;
				OnPropertyChanged("BoxViewEndX");
				PointUpdate();
			}
		}

		private double boxViewEndY;
        public double BoxViewEndY
        {
            get { return boxViewEndY; }
            set
            {
                boxViewEndY = value;
                OnPropertyChanged("BoxViewEndY");
				PointUpdate();
            }
        }

		private string panPoint;
        public string PanPoint
		{
			get { return panPoint; }
			set
			{
				panPoint = value;
				OnPropertyChanged("PanPoint");
			}
		}

        public void PointUpdate()
		{
			PanPoint = string.Format("({0:0.00}, {1:0.00}) => ({2:0.00}, {3:0.00})", new string[]
			{
				BoxViewStartX.ToString(),
				BoxViewStartY.ToString(),
				BoxViewEndX.ToString(),
				BoxViewEndY.ToString(),
			});
		}
	}
}
