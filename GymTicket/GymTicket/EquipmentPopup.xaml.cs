using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.IO;

namespace GymTicket
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentPopup : ContentPage
    {
        Equipment globalEq = new Equipment();
        static HttpClient client = new HttpClient();
        //static int equipmentStatus;
        public EquipmentPopup(Equipment eq)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://192.168.0.5:3000/");

            EquipmentName.Text = eq.equipName;
            EquipmentImageURL.Source = eq.imageURL;

            globalEq = eq;

            CheckEquipmentStatus();
        }
        public void CheckEquipmentStatus()
        {
            try
            {
                Status(globalEq.equipID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public async void Status(int ID)
        {
            System.Diagnostics.Debug.WriteLine("Checking status for equipment: " + ID);
            var res = await client.GetAsync("/equipmentstatus/" + ID);
            if (res.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("Status successfully checked!");
                var result = await res.Content.ReadAsStringAsync();
                if (result == "1")
                { System.Diagnostics.Debug.WriteLine("Equipment is working!"); ReportBtn.IsEnabled = true; }
                else if (result == "0")
                { System.Diagnostics.Debug.WriteLine("Equipment is not working!"); ReportBtn.IsEnabled = false; }
                else
                { System.Diagnostics.Debug.WriteLine("There was an error retrievng the status"); }
            }
        }

        public void CreateForm(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new IncidentForm(globalEq));
        }
    }
}