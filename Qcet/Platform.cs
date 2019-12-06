using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Qcet
{
    public static class Platform
    {
        public static string Version {
            get {
                if (Device.RuntimePlatform == Device.WPF)
                {
                    return string.Format(
                        "WPF {0}",
                        Environment.Version);
                }
                
                return string.Format(
                    "{0} {1}",
                    DeviceInfo.Platform,
                    DeviceInfo.VersionString);
            }
        }

        public static string Manufacturer {
            get {
                if (Device.RuntimePlatform == Device.WPF)
                {
                    return DeviceIdiom.Unknown.ToString();
                }

                return DeviceInfo.Manufacturer;
            }
        }

        public static string Model {
            get {
                if (Device.RuntimePlatform == Device.WPF)
                {
                    return DeviceIdiom.Unknown.ToString();
                }

                return DeviceInfo.Model;
            }
        }
    }
}
