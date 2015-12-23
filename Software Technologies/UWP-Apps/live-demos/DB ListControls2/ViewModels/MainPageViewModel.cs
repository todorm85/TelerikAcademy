using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPControls.Helpers;

namespace UWPControls.ViewModels
{
    public class MainPageViewModel
    {
        private ObservableCollection<PersonViewModel> people;

        public IEnumerable<PersonViewModel> People
        {
            get
            {
                return this.people;
            }
            set
            {
                if (this.people == null)
                {
                    this.people = new ObservableCollection<PersonViewModel>();
                }

                this.people.Clear();
                value.ForEach(this.people.Add);
            }
        }

        public MainPageViewModel()
        {
            this.People = new ObservableCollection<PersonViewModel>();
        }
    }
}
