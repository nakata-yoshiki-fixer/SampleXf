using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF.ViewModels
{
	public class HomePageViewModel : BaseViewModel
    {
		public HomePageViewModel() : base("HomePageViewModel")
        {
			// ■Header
            // Value
			HeaderTitle = "Home";
			HeaderRightIconSource = ImageSource.FromFile("Icon/setting.png");
			//HeaderLeftIconSource = ImageSource.FromFile("Icon/setting.png");
            
            // Command
			HeaderRightCommand = new Command(() =>
			{
				Application.Current.MainPage.DisplayAlert("Setting", "", "OK");
			});

			HeaderLeftCommand = new Command(() =>
			{
			});


        }

        // ■Property
        // Header
		public string HeaderTitle { get; set; }
		public ImageSource HeaderRightIconSource { get; set; }
		public ImageSource HeaderLeftIconSource { get; set; }
		public ICommand HeaderRightCommand { get; set; }
		public ICommand HeaderLeftCommand { get; set; }
    }
}
