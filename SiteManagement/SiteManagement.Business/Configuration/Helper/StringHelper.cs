﻿namespace SiteManagement.Business.Configuration.Helper
{
    public static class StringHelper
    {
        public static string CreateCacheKey(string userName, int userId)
        {
            return string.Concat(userName.Substring(0, 3), "_", userId);
        }
    }
}
