using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyWayManagerApp.ViewModels
{
    class ProfilePageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion





        #region FirstName
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("FName");
            }
        }
        #endregion


        #region LastName
        private string lastname;

        public string LastName
        {
            get => lastname;
            set
            {
                lastname = value;
                OnPropertyChanged("LName");
            }
        }
        #endregion

        #region UserName
        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        #endregion


        #region Email
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        #endregion


        #region BirthDate
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged("Birthday");
            }
        }
        #endregion



        #region Gender
        private string gender;
        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        #endregion




        public ProfilePageViewModel()
        {
            App theApp = (App)App.Current;
            Manager currentUser = theApp.CurrentUser;
            if (currentUser != null)
            {
                this.Email = currentUser.ManagerEmail;
                this.UserName = currentUser.ManagerUsername;
                this.Name = currentUser.ManagerName;
                this.LastName = currentUser.ManagerLastName;
                this.BirthDate = currentUser.ManagerBirthDay;
                this.Gender = currentUser.ManagerGenedr;
            }


        }

        public ICommand NevigateToCL => new Command(ToUpdate);
        void ToUpdate()
        {

            Page p = new ClientList();
            App.Current.MainPage = p;
        }


        public ICommand NevigateToCarL => new Command(ToUpdate1);
        void ToUpdate1()
        {

            Page p = new CarList();
            App.Current.MainPage = p;
        }


        public ICommand NevigateToAddCar => new Command(ToUpdate2);
        void ToUpdate2()
        {

            Page p = new AddCar();
            App.Current.MainPage = p;
        }
    }
}
