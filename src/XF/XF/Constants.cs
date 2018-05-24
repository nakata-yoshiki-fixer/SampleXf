using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Xml.XPath;

namespace XF
{
	public class Constants
    {
		private static Constants instance;
        public static Constants GetInstance()
		{
			if (instance == null)
				instance = new Constants();
			return instance;
		}

        private Constants()
        {
			// read config file
			var assembly = typeof(App).GetTypeInfo().Assembly;
			using (var stream = assembly.GetManifestResourceStream("XF.App.config"))
			{
				if (stream != null) 
				{
					using (var reader = new StreamReader(stream))
                    {
                        var xml = XDocument.Parse(reader.ReadToEnd());
                        ReadConfigFile(xml);

                    }
			    }

				ReadEnvironmentVariable();
			}
        }

        private void ReadConfigFile(XDocument xml)
		{
			AppCenterKey_iOS = xml.XPathSelectElement("config/appCenter/ios").Attribute("key").Value;
		}

		private void ReadEnvironmentVariable()
		{
			AppCenterKey_iOS = Environment.GetEnvironmentVariable("APP_CENTER_KEY_IOS") ?? AppCenterKey_iOS;
		}

        // ■View Params
        // Header
		public int HeaderHeight { get; set; } = Device.RuntimePlatform == Device.iOS ? 60 : 40;
		public int HeaderIconSize { get; set; } = 20;
		public Color HeaderBaseColor { get; set; } = Color.FromHex("#4b6fb7");
		public Color HeaderSubColor { get; set; } = Color.White;
        
        // Footer
		public int FooterHeight { get; set; } = 60;
		public int FooterIconSize { get; set; }
		public Color FooterBaseColor { get; set; } = Color.FromHex("#F3F3F3");
		public Color FooterSubColor { get; set; }
        
        // AppCenter
		public string AppCenterKey_iOS { get; set; }
    }
}
