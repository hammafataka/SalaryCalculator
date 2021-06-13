using SalaryCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalaryCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalaryView : ContentPage
    {
        SalaryViewModel vm;
        public SalaryView()
        {
            vm = new SalaryViewModel();
            vm.load();
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}