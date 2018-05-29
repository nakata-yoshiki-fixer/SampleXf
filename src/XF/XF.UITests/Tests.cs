using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace XF.UITests
{
	//[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

		[SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void T00_Repl()
		{
			app.Repl();
		}

        // ■ボタン関連
		// ボタンがあるかどうかのテスト(Textプロパティを拾う)
        [Test]
        public void T01_ButtonTest()
		{
			var result = app.WaitForElement("Alert").Any();
			Assert.IsTrue(result);
		}

		// ボタンがあるかどうかのテスト(AutomationIDを拾う)
        [Test]
        public void T02_ButtonTest()
		{
			var result = app.WaitForElement("HomePage.AlertButton").Any();
			Assert.IsTrue(result);
		}

        // DisplayAlertが表示されるかどうかのテスト
        [Test]
        public void T03_ButtonTest()
		{
			app.Tap("HomePage.AlertButton");
			var result = app.WaitForElement("Button Clicked").Any();
			result &= app.WaitForElement("SampleDialog").Any();
			result &= app.WaitForElement("OK").Any();
			Assert.IsTrue(result);
		}

        // DisplayAlertのOK押下後にラベルの表示値が正しいかどうかのテスト
        [Test]
        public void T04_ButtonTest()
		{
			app.WaitForNoElement("DisplayAlert OK");
			app.Tap(c => c.Text("OK"));
			var result = app.WaitForElement("DisplayAlert OK").Any();
			Assert.IsTrue(result);
		}
    }
}
