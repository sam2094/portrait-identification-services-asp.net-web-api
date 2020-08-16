using FaceRecognizer.Common.Helpers;
using System;
using System.Configuration;

namespace FaceRecognizer.Common.ConfigManager
{
    public class ConfigOperations : IConfigOperations
    {
        public string Get(string key)
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
