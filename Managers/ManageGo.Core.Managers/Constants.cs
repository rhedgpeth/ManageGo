namespace ManageGo.Core.Managers
{
    public static class Constants
    {
        public static string BaseApiUrl
        {
            get
            {
                return "http://mg-qa.dynamo-ny.com/api/pmc_v2/";    
            }
        }

        public static class SecureStorageKeys
        {
            public const string AccessToken = "AccessToken";
        }
    }
}
