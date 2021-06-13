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
    public partial class MonthlyNote : ContentPage
    {
        MonthlyViewModel vm;

        public MonthlyNote()
        {
            InitializeComponent();
            vm = new MonthlyViewModel();
            this.BindingContext = vm;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Run(() => vm.LoadSqlDataCommand.Execute(null));
        }
    }
}