using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.Logics
{
    public static class DisplayDialogLogic
    {
		public static async Task Alert(string title, string message, string cancel)
		{
			var currentPage = Application.Current?.MainPage;
			if (currentPage != null)
				await currentPage.DisplayAlert(title, message, cancel);
		}

		public static async Task<bool> Alert(string title, string message, string accept, string cancel)
        {
			var currentPage = Application.Current?.MainPage;
			if (currentPage == null)
				return false;

            return await currentPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
