using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SalaryCalculator.ViewModels
{
    public class SalaryViewModel:BaseViewModel
    {
        public List<string> PickerItemSource { get; }
        private string selectedPickerItem;

        public string SelectedPickerItem
        {
            get { return selectedPickerItem; }
            set {SetProperty(ref selectedPickerItem , value); }
        }
        private string resultLabel;

        public string ResultLabel
        {
            get { return resultLabel; }
            set {SetProperty(ref resultLabel , value); }
        }

        private int perHourEntry;
        public int PerHourEntry
        {
            get { return perHourEntry; }
            set {SetProperty(ref perHourEntry , value); }
        }
        private int hoursEntry;
        public int HoursEntry
        {
            get { return hoursEntry; }
            set { SetProperty(ref hoursEntry, value); }
        }
        private int daysEntry;
        public int DaysEntry
        {
            get { return daysEntry; }
            set { SetProperty(ref daysEntry, value); }
        }
        public ICommand CalculateCommand { get; set; }
        public ICommand LoadCurrency { get; set; }
        void Calculate()
        {
            ResultLabel = (perHourEntry * hoursEntry * daysEntry).ToString()+" "+SelectedPickerItem;
        }
        public void load()
        {
            PickerItemSource.Add("CZK");
            PickerItemSource.Add("$");
            PickerItemSource.Add("€");
        }
        public SalaryViewModel()
        {
            LoadCurrency = new Command(() => load());
            PickerItemSource = new List<string>();
            CalculateCommand = new Command(()=> Calculate());
        }
    }
}
