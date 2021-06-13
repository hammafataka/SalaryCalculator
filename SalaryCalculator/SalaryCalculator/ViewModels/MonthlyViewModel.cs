using SalaryCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SalaryCalculator.ViewModels
{
    public class MonthlyViewModel:BaseViewModel 
    {
        public ObservableCollection<SalaryInfo> salaries { get; }
        public SalaryInfo salaryinfo { get; set; }
        public int hour { get; set; }
        public int PerHour { get; set; }

        public ICommand LoadDataCommand { get; set; }
        public ICommand LoadSqlDataCommand { get; set; }
        public ICommand DeleteDataCommand { get; set; }
        public ICommand ClearDataCommand { get; set; }

        public async Task clear()
        {
            bool op;
            op = await App.DbContext.DeleteAllItems<SalaryInfo>();
            if (op)
            {
                await LoadSql();
                await Application.Current.MainPage.DisplayAlert("success!", "Items Cleared ...", "OK");
            }
            else
            {
                await LoadSql();
                await Application.Current.MainPage.DisplayAlert("Error!", "Items Was NOT Cleared ...", "OK");
            }
        }
        public async Task delete()
        {
            bool op;
            op = await App.DbContext.DeleteItem<SalaryInfo>(salaryinfo);
            if (op)
            {
                await LoadSql();
                await Application.Current.MainPage.DisplayAlert("success!", "Item Deleted ...", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Item Was NOT Deleted ...", "OK");
            }
        }

        public async Task LoadData()
        {
            int id = 1;
            bool op;
            salaryinfo.id = id + 1;
            salaryinfo.Hours = hour;
            salaryinfo.PerHour = PerHour;
            salaryinfo.Total = hour * PerHour;
            op = await App.DbContext.AddItem(salaryinfo);
            if (op)
            {

                salaries.Add(salaryinfo);
                await LoadSql();
                await Application.Current.MainPage.DisplayAlert("success!", "Item added ...", "OK");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error!", "Item Was NOT added ...", "OK");
        }
        public async Task LoadSql()
        {
            List<SalaryInfo> salary = await App.DbContext.GetItems<SalaryInfo>();
            salaries.Clear();
            foreach (SalaryInfo s in salary)
            {
                salaries.Add(s);
            }
        }
        public MonthlyViewModel()
        {
            Task.Run(async () => await LoadSql());
            LoadSqlDataCommand = new Command(async () => await LoadSql());
            DeleteDataCommand = new Command(async () => await delete());
            ClearDataCommand = new Command(async () => await clear());
            salaries = new ObservableCollection<SalaryInfo>();
            hour = new int();
            PerHour = new int();
            salaryinfo = new SalaryInfo();
            LoadDataCommand = new Command(async () => await LoadData());
        }
    }
}
