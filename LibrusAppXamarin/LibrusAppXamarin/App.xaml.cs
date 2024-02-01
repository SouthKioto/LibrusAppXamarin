using LibrusAppXamarin.Data;
using LibrusAppXamarin.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibrusAppXamarin
{
    

    public partial class App : Application
    {
        static DataBase database;

        public static DataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "librusApp.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
