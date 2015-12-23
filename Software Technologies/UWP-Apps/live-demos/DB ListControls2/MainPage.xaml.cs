using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPControls.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var vm = new MainPageViewModel();
            vm.People = new ObservableCollection<PersonViewModel>
            {
                new PersonViewModel("John", 15),
                new PersonViewModel("Jane", 25),
            };

            this.ViewModel = vm;
        }

        public MainPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }


        private void OnShowButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedPerson = (int)this.lbPeople.SelectedValue;

        }

        private void OnAddPersonButtonClick(object sender, RoutedEventArgs e)
        {
            var name = this.tbName.Text;
            var age = int.Parse((this.tbAge.Text));

            var people = new ObservableCollection<PersonViewModel>();
            people.Add(new PersonViewModel(name, age));

            this.ViewModel.People = people;
        }
    }
}
