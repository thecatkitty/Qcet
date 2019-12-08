using Xamarin.Forms;

namespace Qcet
{
    public static class Settings
    {
        public static string UrlBase
        {
            get => Application.Current.Properties.ContainsKey("UrlBase")
                ? Application.Current.Properties["UrlBase"] as string
                : "http://localhost:8000/";
            set => Application.Current.Properties["UrlBase"] = value;
        }
    }
}
