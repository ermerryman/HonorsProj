using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GymTicket
{
    public class EquipmentDatabase
    {
        private SQLiteConnection conn;
        public ObservableCollection<Equipment> EquipmentList { get; set; }

        public EquipmentDatabase()
        {
            conn = DependencyService.Get<ISQLiteConnector>().GetConnection();
            System.Diagnostics.Debug.WriteLine(conn.DatabasePath);
            this.EquipmentList = new ObservableCollection<Equipment>(conn.Table<Equipment>());
            if (!conn.Table<Equipment>().Any())
            {
                System.Diagnostics.Debug.WriteLine("There is no data!");
            }
            else
            {
                GetEquipment();
            }
        }

        public void GetEquipment()
        {
            foreach (Equipment eq in EquipmentList)
            {
                eq.imageURL = "http://192.168.0.5:3000/images/" + eq.imageURL;
            }
        }
    }
}
