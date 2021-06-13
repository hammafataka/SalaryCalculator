using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SalaryCalculator.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected bool SetProperty<T>(ref T storage,T value, [CallerMemberName] string PropertyName = "")
        {
            if (object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set {SetProperty(ref isBusy ,value); }
        }

    }
}
