using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PopthatpillTest.PLC
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("/Deakin/2016 Tri 2/SIT313/Assignment 2/Popthatpill/Popthatpill/Popthatpill.Droid/bin/Release/Popthatpill.Popthatpill.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

