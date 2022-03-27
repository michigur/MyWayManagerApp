using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Models;
using Xamarin.Essentials;
using System.Linq;
namespace MyWayManagerApp.ViewModels
{
    class ManagerLoginViewModel : INotifyPropertyChanged
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

        public ManagerLoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        private string serverStatus;
        public string ServerStatus
        {
            get { return serverStatus; }
            set
            {
                serverStatus = value;
                OnPropertyChanged("ServerStatus");
            }
        }

        public async void OnSubmit()
        {
           // ServerStatus = "מתחבר לשרת...";
           // await App.Current.MainPage.Navigation.PushModalAsync(new Views.ServerStatusPage(this));
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            Manager user = await proxy.LoginAsync(Email, Password);
            if (user == null)
            {
                //await App.Current.MainPage.Navigation.PopModalAsync();
                await App.Current.MainPage.DisplayAlert("שגיאה", "התחברות נכשלה, בדוק שם משתמש וסיסמה ונסה שוב", "בסדר");
            }
            else
            {

                    

                    Page p = new NavigationPage(new Views.HomePage());
                    App.Current.MainPage = p;
                


            }
        }

       
    }
}
