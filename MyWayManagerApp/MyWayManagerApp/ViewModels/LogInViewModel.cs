using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;

namespace MyWayManagerApp.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public LogInViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }



        public async void OnSubmit()
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            Manager user = await proxy.LoginAsync(Email, Password);
            if (user == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Login failed, please check Email and password and try again", "OK");
            }
            else
            {

                App theApp = (App)Application.Current;
                theApp.CurrentUser = user;
                Page p = new HomePage();
                App.Current.MainPage = new NavigationPage(p);



            }
        }

    }
}
