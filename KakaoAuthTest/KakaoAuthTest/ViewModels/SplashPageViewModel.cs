using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace KakaoAuthTest.ViewModels
{
    public class SplashPageViewModel : ViewModelBase
    {
        private string _SplashImagePath;
        public string SplashImagePath
        {
            get => _SplashImagePath;
            set { SetProperty(ref _SplashImagePath, value); }
        }
        public ICommand SplashScreenCommand { get; set; }

        public SplashPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Splash Page";

            string imgFile = "splash.jpg";
            if (Device.RuntimePlatform == Device.UWP) imgFile = "Assets\\" + imgFile;
            SplashImagePath = imgFile;

            SplashScreenCommand = new Command(ExecuteSplashScreenCommand);
        }

        private async void ExecuteSplashScreenCommand(object obj)
        {
            Image splashImage;
            if (obj != null)
            {
                splashImage = obj as Image;

                //2초동안 머문다.   
                await splashImage.ScaleTo(1, 2000);
                // 1.5초 동안 0.9배 작아진다.
                await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
                // 1.2초 동안 150배 커진다.
                await splashImage.ScaleTo(150, 1200, Easing.Linear);

                await NavigationService.NavigateAsync("app:///LottieAnimationPage");
            }
        }
    }
}

