using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Navigation;

namespace SkieurMVVML.ViewModel
{
    public class DetailPageViewModel : ViewModelBase, IDetailPageViewModel
    {
        private INavigationService _iNavigationService;
        public ICommand NavigateToCommand { get; set; }
        public Skieur Skieur { get; set; }
        private Skieur _selectedSkieur;

        public Skieur SelectedSkieur
        {
            get { return _selectedSkieur; }
            set { Set(() => SelectedSkieur, ref _selectedSkieur, value); }
        }


        public DetailPageViewModel(INavigationService iNavigationService)
        {
            _iNavigationService = iNavigationService;
            SelectedSkieur = _iNavigationService.GetParameters().GetValue<Skieur>("");
            Messenger.Default.Register<Skieur>(this, skieur => { SelectedSkieur = skieur; });
            NavigateToCommand = new Command<String>(NavigateTo);
        }
        private void NavigateTo(string obj)
        {
            _iNavigationService.NavigateTo(obj);
        }
    }
}
