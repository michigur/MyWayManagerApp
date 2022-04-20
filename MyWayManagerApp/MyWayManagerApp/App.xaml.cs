using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MyWayManagerApp
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }

        public Manager CurrentUser { get; set; }

        public List<Car> Cars { get; set; }
        //The list of phone types
        public List<Client> ClientsList { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new LogIn();
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
