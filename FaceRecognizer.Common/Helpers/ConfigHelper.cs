using System;
using System.Configuration;

namespace FaceRecognizer.Common.Helpers
{
    public class ConfigHelper
    {
        public static string GetAppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
