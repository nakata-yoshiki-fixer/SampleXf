using System;
using XF.Interfaces;
using LocalAuthentication;
using Foundation;
using Xamarin.Forms;
using XF.iOS.DependencyServices;
using System.Threading.Tasks;

[assembly : Dependency(typeof(LocalAuthenticator))]
namespace XF.iOS.DependencyServices
{
	public class LocalAuthenticator : ILocalAuthenticator
	{
		private LAContext context;

		public bool CheckDevice()
        {
			if(context == null)
			    context = new LAContext();
			
			var result = context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out NSError nSError);

			return result;
        }

		public async Task<bool> AuthAsync()
		{
			if (context == null)
                context = new LAContext();

			return (await context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthentication, "指紋認証")).Item1;
		}      
	}
}
