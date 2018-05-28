using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Controls;
using XF.Logics;

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
					IconSource = "Icon/calender.png",
					Text = "カレンダー",
					OnItemSelect = new Command(async() =>
					{
						await DisplayDialogLogic.Alert("FooterClick", "Item1", "OK");
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
	}
}
