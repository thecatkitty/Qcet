using System;
using Xamarin.Essentials;

namespace Qcet.WPF
{
    class PlatformProvider : Qcet.PlatformProvider
    {
        override public string Version
        {
            get => string.Format("WPF {0}", Environment.Version);
        }

        override public string Manufacturer
        {
            get => DeviceIdiom.Unknown.ToString();
        }

        override public string Model
        {
            get => DeviceIdiom.Unknown.ToString();
        }
    }
}
