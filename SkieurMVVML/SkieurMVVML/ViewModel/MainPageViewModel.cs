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
using GalaSoft.MvvmLight.Messaging;

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
                Set(() => SelectedSkieur, ref _selectedSkieur,value);
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
            NavigateToCommand = new Command<String>(NavigateTo);
            Refresh();
        }

        private void NavigateTo(string obj)
        {
            Messenger.Default.Send<Skieur>(SelectedSkieur);
            _iNavigationService.NavigateTo(obj, new NavigationParameters { { "", SelectedSkieur } });
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
