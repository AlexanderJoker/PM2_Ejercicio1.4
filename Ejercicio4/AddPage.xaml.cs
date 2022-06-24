using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        MediaFile FileFoto = null;

        public AddPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            string folderPath = "/storage/emulated/0/Android/data/com.companyname.ejercicio4/files/Pictures/MisFotos/";


            string[] files = Directory.GetFiles(folderPath, "*.jpg");



            //await DisplayAlert("", files.Length + "", "OK");

           // RetriveImageFromLocation(folderPath);
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileFoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Name = Nombre.Text,
                    Directory = "MisFotos",
                    CustomPhotoSize = 50
                });

                await DisplayAlert("Direcctorio", FileFoto.Path, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }



            if (FileFoto != null)
            {
                Foto.Source = ImageSource.FromStream(() => {

                    return FileFoto.GetStream();
                });
            }
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }


        public async void RetriveImageFromLocation(string location)
        {
            Image image = new Image();
            var memoryStream = new MemoryStream();

            using (var source = File.OpenRead(location))
            {
                await source.CopyToAsync(memoryStream);
            }

            Foto.Source = ImageSource.FromStream(() => {
                return new MemoryStream(memoryStream.GetBuffer());
            });

            //return image;
        }
    }

}
