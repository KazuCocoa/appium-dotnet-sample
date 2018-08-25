using System;

namespace AppiumDotNetSamples.Helper
{
    public static class Env
    {
        static public bool IsSauce()
        {
            return Environment.GetEnvironmentVariable("SAUCE_LABS") != null;
        }

        public static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        public static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
        public static Uri sauceURI = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
        public static Uri localUrl = new Uri("http://localhost:4723/wd/hub");
    }

    public static class App
    {
        static public String IOSApp()
        {
            return Env.IsSauce() ? "http://appium.github.io/appium/assets/TestApp7.1.app.zip" : System.IO.Path.GetFullPath("../../../apps/TestApp.app.zip");
        }

        static public String AndroidApp()
        {
            return Env.IsSauce() ? "http://appium.github.io/appium/assets/ApiDemos-debug.apk" : System.IO.Path.GetFullPath("../../../apps/ApiDemos-debug.apk");
        }
    }
}
