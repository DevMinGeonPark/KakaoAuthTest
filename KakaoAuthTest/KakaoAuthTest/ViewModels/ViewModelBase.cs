using Prism.Mvvm;
using Prism.Navigation;
using System.ComponentModel;

namespace KakaoAuthTest.ViewModels
{
    public class ViewModelBase : BindableBase, IDestructible, INavigatedAware
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        private bool _isBusy;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Destroy()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
