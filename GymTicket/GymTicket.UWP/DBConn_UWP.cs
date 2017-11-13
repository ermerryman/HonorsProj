using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
using GymTicket.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(DBConn_UWP))]
namespace GymTicket.UWP
{
    class DBConn_UWP : ISQLiteConnector
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "gymDB.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
