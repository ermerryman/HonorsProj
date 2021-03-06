﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;

namespace GymTicket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidentForm : ContentPage
    {
        Equipment globalEq = new Equipment();
        static HttpClient client = new HttpClient();
        Plugin.Media.Abstractions.MediaFile imageFile;
        public IncidentForm(Equipment eq)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://192.168.0.5:3000/");

            globalEq = eq;
        }

        //
        // Use this to send multipart form with only text
        //
        public async void ReportIssue(object sender, EventArgs e)
        {
            var jsonData = JsonConvert.SerializeObject(new { userDesc = Description.Text });

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/reportIncident/"+globalEq.equipID, content);

            var result = await response.Content.ReadAsStringAsync();
            if (result == "E-mail sent!")
            { var ok = DisplayAlert("Success", "The issue has been reported.", "OK"); }
            else
            { var notOk = DisplayAlert("Uh-Oh", "There was an error reporting the issue.", "OK"); }
            Page x = await Navigation.PopModalAsync();
        }

        //
        // Use this to send multipart form with image
        //
        public async void ReportIssueForm(object sender, EventArgs e)
        {
            var jsonData = JsonConvert.SerializeObject(new { userDesc = Description.Text });
            StringContent descData = new StringContent(Description.Text);
            StreamContent imageData = new StreamContent(imageFile.GetStream());

            MultipartFormDataContent form = new MultipartFormDataContent(); 

            form.Add(descData,"userDesc");
            form.Add(imageData, "image", "upload.jpg");

            var response = await client.PostAsync("/api/reportIncident/" + globalEq.equipID, form);

            var result = await response.Content.ReadAsStringAsync();
            if (result == "E-mail sent!")
            { var ok = DisplayAlert("Success", "The issue has been reported.", "OK"); }
            else
            { var notOk = DisplayAlert("Uh-Oh", "There was an error reporting the issue.", "OK"); }
            Page x = await Navigation.PopModalAsync();
            //TODO: Figure out how to reload ContentPage after pop
        }

        public async void TakePhoto()
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                System.Diagnostics.Debug.WriteLine("Camera available!");

                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                { SaveToAlbum = false, SaveMetaData = false };

                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                if(file != null)
                {
                    System.Diagnostics.Debug.WriteLine(file.Path);
                    imageFile = file;

                    UserPic.Source = ImageSource.FromStream(() => { return file.GetStream(); });

                    return;
                }
                else
                {
                    return;
                }
            }
        }
    }
}