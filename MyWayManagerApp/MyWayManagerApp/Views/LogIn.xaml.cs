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
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            LogInViewModel context = new LogInViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}