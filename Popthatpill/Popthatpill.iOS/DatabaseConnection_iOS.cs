using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Popthatpill.iOS;
using SQLite;
using System.IO;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace Popthatpill.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "PillsDB.db3";
            string personalFolder = System.Environment.
                GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            return new SQLiteConnection(platform, path);

        }
    }
}