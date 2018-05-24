using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using LocalAuthentication;

namespace XF.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Calabash.Start();
            global::Xamarin.Forms.Forms.Init();
			AppCenter.Start($"ios={Constants.GetInstance().AppCenterKey_iOS};", typeof(Analytics), typeof(Crashes));
            
            LoadApplication(new App());


            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public void Auth()
		{
			var userDefaults = new NSUserDefaults();
			// 書き込みサンプル
			//userDefaults.SetBool(false, "touch_id");

			if(userDefaults.BoolForKey("touch_id"))
			{
				var context = new LAContext();
                NSError AuthError;
                var myReason = new NSString("To add a new chore");

                if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out AuthError))
                {
                    var replyHandler = new LAContextReplyHandler((success, error) => {
                        this.InvokeOnMainThread(async () => {
                            if (success)
                            {
                                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Success", "", "OK");
                            }
                            else
                            {
                                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "", "OK");
                            }
                        });
                    });
                    context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, myReason, replyHandler);
                };
			}         
		}
    }
}
