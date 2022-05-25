using System;
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
using System.Collections.ObjectModel;

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

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                if (this.isRefreshing != value)
                {
                    this.isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }


        List<Client> clients = new List<Client>();
        public ObservableCollection<Client> MonkeyList { get; }

        public ClientListViewModel()
        {
            MonkeyList = new ObservableCollection<Client>();
            OnGo();
            this.isRefreshing = false;
            CreateMonkeyCollection();
        }

        async void CreateMonkeyCollection()
        {
          
            foreach (Client m in clients)
            {
                this.MonkeyList.Add(m);
            }
        }


        public ICommand Go => new Command(OnGo);
        public async void OnGo()
        {
            clients = await this.LoadClients((App)App.Current);
        }

        private async Task<List<Client>> LoadClients(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.ClientsList = await proxy.GetUsersAsync();
            return theApp.ClientsList;
        }






        //Selection changed 
        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public void OnSelectionChanged(Object obj)
        {
            if (obj is Client)
            {
                Client chosenMonkey = (Client)obj;
                Page monkeyPage = new ShowClient();
                ShowClientViewModel monkeyContext = new ShowClientViewModel
                {
                    Name = chosenMonkey.ClientName,
                    LastName = chosenMonkey.ClientsLastName,
                    UserName = chosenMonkey.ClientsUsername,
                    Email = chosenMonkey.ClientsEmail,
                    Password = chosenMonkey.ClientsPassword,
                    Location = chosenMonkey.ClientCurrentLocation,
                    Birthday = chosenMonkey.ClientsBirthDay
                };
                monkeyPage.BindingContext = monkeyContext;
                monkeyPage.Title = monkeyContext.Name;
                if (NavigateToPageEvent != null)
                    NavigateToPageEvent(monkeyPage);
            }
        }


        //Delete Client
        public ICommand DeleteCommand => new Command<Client>(RemoveMonkey);
        void RemoveMonkey(Client m)
        {
            if (MonkeyList.Contains(m))
            {
                MonkeyList.Remove(m);
            }

        }





        //Refresh collection
        public ICommand RefreshCommand => new Command(RefreshMonkeys);

        async void RefreshMonkeys()
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            List<Client> theMonkeys = await proxy.GetUsersAsync();
            this.MonkeyList.Clear();
            foreach (Client m in theMonkeys)
            {
                this.MonkeyList.Add(m);
            }
            this.IsRefreshing = false;
        }





        #region Events
        //Events
        //This event is used to navigate to the monkey page
        public Action<Page> NavigateToPageEvent;
        #endregion
    }
}
