﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;
//using Android.Content.Res;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;

namespace MyWayManagerApp.ViewModels
{
    class ClientListViewModel : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ClientListViewModel()
        {
            OnGo();
        }

        public ICommand Go => new Command(OnGo);
        public async void OnGo()
        {
            List<Client> clients = await this.LoadClients((App)App.Current);
        }

        private async Task<List<Client>> LoadClients(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.ClientsList = await proxy.GetUsersAsync();
            return theApp.ClientsList;
        }
    }
}
