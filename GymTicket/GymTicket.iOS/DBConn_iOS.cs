using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using SQLite;
using System.IO;
using GymTicket.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DBConn_iOS))]
namespace GymTicket.iOS
{
    class DBConn_iOS : ISQLiteConnector
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "gymDB.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}