using Plugin.Settings;
using Plugin.Settings.Abstractions;
using KakaoAuthTest.Extensions;
using KakaoAuthTest.Models;

namespace KakaoAuthTest
{
    class AppSettings
    {
        /// <summary>
        /// 현재 App의 설정(Settings) 가져오기
        /// </summary>
        private static ISettings Settings => CrossSettings.Current;

        /// <summary>
        /// 사용자 가져오기 및 설정 속성
        /// </summary>
        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }
        /// <summary>
        /// 설정(Settins)에서 사용자 데이터 삭제
        /// </summary>
        public static void RemoveUserData()
        {
            Settings.Remove(nameof(User));
        }
    }
}
