namespace KakaoAuthTest.Models.Providers
{
    public class OAuth2ProviderFactory
    {
        public static OAuth2Base CreateProvider(SNSProvider provider)
        {
            OAuth2Base oAuth2 = null ;

            switch (provider)
            {
                case SNSProvider.Kakao:
                    oAuth2 = KakaoOAuth2.Instance;
                    break;
            }

            return oAuth2;
        }
    }
}