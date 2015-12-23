using System.Collections.ObjectModel;
using UWPControls.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
    }
}