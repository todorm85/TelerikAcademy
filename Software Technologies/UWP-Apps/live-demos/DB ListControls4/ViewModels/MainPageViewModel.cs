namespace UWPControls.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using UWPControls.Helpers;

    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<PersonViewModel> people;

        private PersonViewModel newPerson;

        public MainPageViewModel()
        {
            this.People = new ObservableCollection<PersonViewModel>();
            this.FillWithSampleData();
            this.Add = new DelegateCommand(this.AddPerson);
        }

        private void FillWithSampleData()
        {
            for (int i = 0; i < 10; i++)
            {
                this.people.Add(new PersonViewModel($"Person #{i}", i));
            }
        }

        public ICommand Add { get; private set; }

        public PersonViewModel NewPerson
        {
            get
            {
                if (this.newPerson == null)
                {
                    this.newPerson = new PersonViewModel("", 0);
                }

                return this.newPerson;
            }

            set
            {
                this.newPerson = value;
                this.RaisePropertyChanged("NewPerson");
            }
        }

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

        internal void AddPerson()
        {
            this.people.Add(PersonViewModel.FromPerson(this.NewPerson));
            this.newPerson.Age = 0;
            this.newPerson.Name = "";
        }
    }
}