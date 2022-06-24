using Ejercicio4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verLista : ContentPage
    {
        public verLista()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            string folderPath = "/storage/emulated/0/Android/data/com.companyname.ejercicio4/files/Pictures/MisFotos/";

            var filePathDir = Path.Combine(folderPath, "folder");
            if (!File.Exists(filePathDir))
            {
                Directory.CreateDirectory(filePathDir);
            }

            string[] files = Directory.GetFiles(folderPath, "*.jpg");

            List<imagen> imagenes = new List<imagen>();

            imagen temp = null;
            foreach (var item in files)
            {
                temp = new imagen();

                temp.nombre = item.Remove(0, 82);
                temp.descripcion = item;

                imagenes.Add(temp);
            }


            listaImagen.ItemsSource = imagenes;
        }

    }
}
