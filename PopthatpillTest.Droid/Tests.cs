﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace PopthatpillTest.Droid
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.Android.ApkFile("/Deakin/2016 Tri 2/SIT313/Assignment 2/Popthatpill/Popthatpill/Popthatpill.Droid/bin/Release/Popthatpill.Popthatpill.apk").StartApp();

        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
        }
    }
}

