using GalaSoft.MvvmLight;
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

        public DetailPageViewModel(INavigationService iNavigationService)
        {
            _iNavigationService = iNavigationService;
            Skieur = _iNavigationService.GetParameters().GetValue<Skieur>("");
            NavigateToCommand = new Command<String>(NavigateTo);
        }
        private void NavigateTo(string obj)
        {
            _iNavigationService.NavigateTo(obj);
        }
    }
}
