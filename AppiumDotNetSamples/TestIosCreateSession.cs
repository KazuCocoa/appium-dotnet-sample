﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using AppiumDotNetSamples.Helper;

namespace AppiumDotNetSamples
{
    [TestFixture()]
    public class IOSCreateSessionTest
    {

        private AppiumDriver<IOSElement> driver;

        [TestFixtureSetUp()]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "iOS");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "10.3");
            capabilities.SetCapability(MobileCapabilityType.AutomationName, "XCUITest");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "iPhone 6");
            capabilities.SetCapability(MobileCapabilityType.App, App.IOSApp());

            Uri serverUri = Env.IsSauce() ? Env.sauceURI : Env.localUrl;

            driver = new IOSDriver<IOSElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [Test()]
        public void TestShouldCreateAndDestroyIOSSessions()
        {
            IOSElement element = driver.FindElementByClassName("XCUIElementTypeApplication");
            String application_name = element.GetAttribute("name");
            Assert.AreEqual("TestApp", application_name);

            driver.Quit();

            Assert.Throws<WebDriverException>(
                () => { element.GetAttribute("name"); });
        }
    }
}