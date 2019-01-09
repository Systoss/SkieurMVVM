using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Views;
using Xamarin.Forms.Navigation;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Model;
using SkieurMVVML.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;

namespace SkieurMVVML.ViewModel
{
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        private ISkieurService _dataService;
        private INavigationService _iNavigationService;
        private Skieur _selectedSkieur;

        public Skieur SelectedSkieur {
            get { return _selectedSkieur; }
            set
            {
                _selectedSkieur = value;
                NavigateTo("DetailPage");
            }
        }
        public ObservableCollection<Skieur> Skieurs { get; set; }

        public ICommand NavigateToCommand { get; set; }

        public MainPageViewModel(ISkieurService dataService,INavigationService iNavigationService)
        {
            _dataService = dataService;
            Skieurs = new ObservableCollection<Skieur>();
            _iNavigationService = iNavigationService;
            NavigateToCommand = new RelayCommand<String>(NavigateTo);
            Refresh();
        }

        private void NavigateTo(string obj)
        {
            _iNavigationService.PopToRootAsync();
            _iNavigationService.NavigateTo(obj, new NavigationParameters { { "", _selectedSkieur } });
        }

        public async void Refresh()
        {
            Skieurs.Clear();
            var lstSkieurs = await _dataService.Refresh();
            foreach (var item in lstSkieurs)
            {
                Skieurs.Add(item);
            }
        }
    }
}
