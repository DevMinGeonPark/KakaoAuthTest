using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Plugin.Settings.Abstractions;

namespace KakaoAuthTest.Extensions
{
    public static class ISettingsExtensions
    {
        /// <summary>
        /// 설정(Setting) 값을 가져온다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings">ISettings</param>
        /// <param name="key">키</param>
        /// <param name="default">기본 값</param>
        /// <returns></returns>
        public static T GetValueOrDefault<T>(this ISettings settings, string key, T @default) where T : class
        {
            string serialized = settings.GetValueOrDefault(key, string.Empty);
            T result = @default;

            try
            {
                JsonSerializerSettings serializeSettings = GetSerializerSettings(); //
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deserializing settings value: {ex}");
            }

            return result;
        }

        /// <summary>
        /// 설정(Setting)을 추가 또는 업데이트
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings">ISettings</param>
        /// <param name="key">키</param>
        /// <param name="obj">값</param>
        /// <returns></returns>
        public static bool AddOrUpdateValue<T>(this ISettings settings, string key, T obj) where T : class
        {
            try
            {
                JsonSerializerSettings serializeSettings = GetSerializerSettings();
                string serialized = JsonConvert.SerializeObject(obj, serializeSettings);

                return settings.AddOrUpdateValue(key, serialized);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error serializing settings value: {ex}");
            }

            return false;
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            //카멜표기법으로 직렬화
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

    }
}
