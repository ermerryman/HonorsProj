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
    public partial class MenuPageTab2 : ContentPage
    {
        public MenuPageTab2()
        {
            InitializeComponent();

            ScheduleLV.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            var schedule = new DayOfWeek();
            ScheduleLV.ItemsSource = schedule.getDays();
        }

        public class DayOfWeek
        {
            public string Day { get; set; }
            public string Activity { get; set; }
            public string Time { get; set; }

            public List<DayOfWeek> getDays()
            {
                List<DayOfWeek> days = new List<DayOfWeek>()
                {
                    new DayOfWeek(){Day="Monday",Activity="Zumba",Time="9:00am-10:00am\nTesting"},
                    new DayOfWeek(){Day="Tuesday",Activity="HIIT",Time="9:00am-10:00am"},
                    new DayOfWeek(){Day="Wednesday",Activity="Crossfit",Time="9:00am-10:00am"},
                    new DayOfWeek(){Day="Thursday",Activity="Yoga",Time="9:00am-10:00am"},
                    new DayOfWeek(){Day="Friday",Activity="Jazzercize",Time="9:00am-10:00am"},
                    new DayOfWeek(){Day="Saturday",Activity="Kettlebell",Time="9:00am-10:00am"},
                    new DayOfWeek(){Day="Sunday",Activity="Ballroom Dancing",Time="9:00am-10:00am"}
                };

                return days;
            }
        }
    }
}