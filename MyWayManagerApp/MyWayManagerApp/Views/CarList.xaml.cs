using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayManagerApp.ViewModels;
namespace MyWayManagerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarList : ContentPage
    {
        public CarList()
        {
            CarListViewModel context = new CarListViewModel();
            context.NavigateToPageEvent += NavigateToAsync;
            this.BindingContext = context;
            InitializeComponent();
        }


        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
    }
}