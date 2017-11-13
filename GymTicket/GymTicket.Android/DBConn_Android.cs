using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
using GymTicket.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DBConn_Android))]
namespace GymTicket.Droid
{
    public class DBConn_Android : ISQLiteConnector
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "gymDB.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            System.Diagnostics.Debug.WriteLine(path);

            CopyDBLocal(path);

            return new SQLiteConnection(path);
        }

        public void CopyDBLocal(string path)
        {
            System.Diagnostics.Debug.WriteLine("Copying file to " + path);
            using (var br = new BinaryReader(Application.Context.Assets.Open("gymDB.db3")))
            {
                using (var bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];
                    int length = 0;
                    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, length);
                    }
                }
            }
        }
    }
}