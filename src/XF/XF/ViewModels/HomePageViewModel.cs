using System;
using Xamarin.Forms;

namespace XF.ViewModels
{
	public class HomePageViewModel : BaseViewModel
    {
		public HomePageViewModel() : base("HomePageViewModel")
        {
			HeaderTitle = "Home";
			HeaderRightIconSource = ImageSource.FromFile("Icon/setting.png");
			HeaderLeftIconSource = ImageSource.FromFile("Icon/setting.png");
        }

		public string HeaderTitle { get; set; }
		public ImageSource HeaderRightIconSource { get; set; }
		public ImageSource HeaderLeftIconSource { get; set; }
    }
}
