using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using SQLite.Net;
using Popthatpill.Droid;
using Popthatpill.ViewModels;


[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Popthatpill.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "PillsDB.db3";
            var path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), dbName);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            return new SQLiteConnection(platform,path);
        }
    }
}