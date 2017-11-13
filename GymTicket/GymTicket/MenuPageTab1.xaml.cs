using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymTicket
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageTab1 : ContentPage
    {
        private EquipmentDatabase database;
        public MenuPageTab1()
        {
            InitializeComponent();

            this.database = new EquipmentDatabase();

            Connection.ItemsSource = database.EquipmentList;
        }

        public void EquipmentSelected(object sender, ItemTappedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(e.Item.GetType().ToString());

            Navigation.PushModalAsync(new EquipmentPopup((Equipment)e.Item));

            ((ListView)sender).SelectedItem = null;
        }
    }
}