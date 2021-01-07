using System.Threading.Tasks;
using KakaoAuthTest.Services.Authentication;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace KakaoAuthTest.ViewModels
{
    public class LottieAnimationPageViewModel : ViewModelBase
    {
        #region private member area
        private IAuthenticationService authenticationService;
        private DelegateCommand authenticationCheckCommand;
        #endregion

        public LottieAnimationPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
            : base(navigationService)
        {
            Title = "Animation Page";
            this.authenticationService = authenticationService;

        }

        #region Command Area
        public DelegateCommand AuthenticationCheckCommand =>
        authenticationCheckCommand ?? (authenticationCheckCommand =
                                      new DelegateCommand
                                        (
                                          async () =>
                                          {
                                              await Task.Delay(3000);
                                              //SNS로긴 정보가 있으면
                                              if (await authenticationService.UserIsAuthenticatedAndValidAsync())
                                              {
                                                  var user = AppSettings.User;
                                                  var p = new NavigationParameters();
                                                  p.Add("user", user);

                                                  await NavigationService.NavigateAsync("NavigationPage/MainPage", p);
                                              }
                                              else//SNS로긴 정보가 없으면
                                              {
                                                  await NavigationService.NavigateAsync("app:///LoginPage");
                                              }
                                          }
                                         )
                                      );
        #endregion
    }
}