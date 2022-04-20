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
            this.BindingContext = new CarListViewModel();
            InitializeComponent();
        }
    }
}