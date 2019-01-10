using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms.Navigation;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Services;
//using GalaSoft.MvvmLight.Views;


namespace SkieurMVVML.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IMainPageViewModel,MainPageViewModel>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<ISkieurService, SkieurService>();
            SimpleIoc.Default.Register<IDetailPageViewModel, DetailPageViewModel>();
        }

        public IMainPageViewModel Main {
            get
            {
                return ServiceLocator.Current.GetInstance<IMainPageViewModel>();
            }
        }

        public IDetailPageViewModel Detail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDetailPageViewModel>();
            }
        }
    }
}
