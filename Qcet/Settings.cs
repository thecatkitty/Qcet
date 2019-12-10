namespace Qcet
{
    public static partial class Settings
    {
        public static string UrlBase
        {
            get => GetFromStorage("http://localhost:8000/");
            set => SetInStorage(value);
        }

        public static string UserName
        {
            get => GetFromStorage<string>(null);
            set => SetInStorage(value);
        }
    }
}
