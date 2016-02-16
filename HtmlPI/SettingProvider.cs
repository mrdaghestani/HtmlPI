using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HtmlPI
{
    public class SettingProvider
    {
        public static string GetAppSetting(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name))
            {
                return ConfigurationManager.AppSettings[name];
            }
            return null;
        }

        public static string GetFromAppSettingOrUseDefault(ref string initedVar, string appSettingName, string defaultValue, Action<string> runInFirstInit = null)
        {
            if (string.IsNullOrEmpty(initedVar))
            {
                initedVar = GetAppSetting(appSettingName);
                if (string.IsNullOrEmpty(initedVar))
                {
                    initedVar = defaultValue;
                }
                if (runInFirstInit != null)
                    runInFirstInit(initedVar);
            }
            return initedVar;
        }
    }
}
