using Prism.Navigation;
using KakaoAuthTest.Models;

namespace KakaoAuthTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Private Fields
        private User user;
        #endregion


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        #region Property Area
        /// <summary>
        /// User 상세 정보
        /// </summary>
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        #endregion

        #region override method area
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            if (parameters.ContainsKey("user"))
                User = (User)parameters["user"];
        }
        #endregion
    }
}
