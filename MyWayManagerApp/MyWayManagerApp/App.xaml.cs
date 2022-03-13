using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayManagerApp.Views;


namespace MyWayManagerApp
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return false; //change this before release!
            }
        }

       

        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
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
