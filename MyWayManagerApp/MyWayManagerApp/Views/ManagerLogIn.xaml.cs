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
    public partial class ManagerLogIn : ContentPage
    {
        public ManagerLogIn()
        {
            this.BindingContext = new ManagerLoginViewModel();
            InitializeComponent();
        }
    }
}