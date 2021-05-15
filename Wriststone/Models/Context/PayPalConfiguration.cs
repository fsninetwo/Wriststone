using PayPal.Api;
using System.Collections.Generic;

namespace Wriststone.Models.Context
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> configurationMap = new Dictionary<string, string>();
            configurationMap.Add("clientId", "ARJgBEMqrbS3XjLYhsELb30dcz9R9Fr6sHwC6ohe0yGiI-3SHLs3j82t7XrVR-mA9-ucUSJxAfxqAbXl");
            configurationMap.Add("clientSecret", "EOWYTY1XAa3qwYuP8BQ24-BgctSuWKnmUVxni1335nspArWBnr4ok8imyAncvfj9t1W-ZXdjZoxeQrzn");
            configurationMap.Add("mode", "sandbox");
            return configurationMap;
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken())
            {
                Config = GetConfig()
            };
            return apiContext;
        }
    }
}