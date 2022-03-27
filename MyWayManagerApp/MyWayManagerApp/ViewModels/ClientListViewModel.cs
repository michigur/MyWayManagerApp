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



       

        private async Task<bool> LoadClients(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.ClientsList = await proxy.GetUsersAsync();
            return theApp.ClientsList != null;
        }
    }
}
