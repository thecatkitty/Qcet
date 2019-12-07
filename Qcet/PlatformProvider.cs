using Xamarin.Essentials;

namespace Qcet
{
    public class PlatformProvider
    {
        virtual public string Version
        {
            get => string.Format(
                "{0} {1}",
                DeviceInfo.Platform,
                DeviceInfo.VersionString);
        }

        virtual public string Manufacturer
        {
            get => DeviceInfo.Manufacturer;
        }

        virtual public string Model
        {
            get => DeviceInfo.Model;
        }
    }
}
