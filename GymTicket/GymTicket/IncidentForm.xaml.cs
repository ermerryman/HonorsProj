using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymTicket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentForm: ContentPage
    {
        Equipment globalEq = new Equipment();
        static HttpClient client = new HttpClient();
        public IncidentForm(Equipment eq)
        {
            InitializeComponent();

            globalEq = eq;
        }

        public void SubmitForm(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Description.Text);
            System.Diagnostics.Debug.WriteLine(globalEq.equipID);
            System.Diagnostics.Debug.WriteLine(globalEq.equipName);
        }

        public async void ReportIssue(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Issue reported for " + globalEq.equipID + ": " + globalEq.equipName);
            var res = await client.GetAsync("/sendEmail/" + globalEq.equipID);
            var result = await res.Content.ReadAsStringAsync();
            if (result == "E-mail sent!")
            { var ok = DisplayAlert("Success", "The issue has been reported.", "OK"); }
            else
            { var notOk = DisplayAlert("Uh-Oh", "There was an error reporting the issue.", "OK"); }
            Page x = await Navigation.PopModalAsync();
        }
    }
}