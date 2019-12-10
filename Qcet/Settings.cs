﻿namespace Qcet
{
    public static class Settings
    {
        public static string UrlBase
        {
            get => Helpers.SettingsStorage.Get("http://localhost:8000/");
            set => Helpers.SettingsStorage.Set(value);
        }

        public static string UserName
        {
            get => Helpers.SettingsStorage.Get<string>(null);
            set => Helpers.SettingsStorage.Set(value);
        }
    }
}
