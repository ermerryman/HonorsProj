using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymTicket
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SignInBtn.Clicked += SignIn;
        }

        private void SignIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage());

            Navigation.RemovePage(this);
        }
    }
}
