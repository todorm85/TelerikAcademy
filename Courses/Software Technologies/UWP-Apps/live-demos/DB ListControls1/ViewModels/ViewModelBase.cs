using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPControls.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            var propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged(this, propertyChangedEventArgs);
        }
    }
}
