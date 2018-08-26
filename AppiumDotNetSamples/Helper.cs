﻿using System;

namespace AppiumDotNetSamples.Helper
{
    public static class Env
    {
        static public bool IsSauce()
        {
            return Environment.GetEnvironmentVariable("SAUCE_LABS") != null;
        }
        
        static public Uri ServerUri()
        {
            String sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            String sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");

            return (sauceUserName == null) || (sauceAccessKey == null)
                ? new Uri("http://localhost:4723/wd/hub")
                : new Uri($"https://{sauceUserName}:{sauceAccessKey}@ondemand.saucelabs.com:80/wd/hub");
        }

        public static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
        public static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
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

        static public String AndroidVersion()
        {
            return Environment.GetEnvironmentVariable("ANDROID_DEVICE_VERSION") ?? "Android";
        }

        static public String AndroidPlatformVersion()
        {
            return Environment.GetEnvironmentVariable("ANDROID_PLATFORM_VERSION") ?? "7.1";
        }
    }
}
