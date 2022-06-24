using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Ejercicio4.Controller;

namespace Ejercicio4
{
    public partial class App : Application
    {
        static DataBase db;
        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM2T4.Ddb3");
                    db = new DataBase(folderPath);
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
