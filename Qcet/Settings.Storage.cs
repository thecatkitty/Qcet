using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Qcet
{
    public static partial class Settings
    {
        private static T GetFromStorage<T>(T defaultValue)
        {
            var callerName = (new StackTrace()).GetFrame(1).GetMethod().Name;
            if (!callerName.StartsWith("get_"))
            {
                throw new ArgumentException("This is not a property getter!");
            }

            var key = callerName.Substring(4);
            return Application.Current.Properties.ContainsKey(key)
                ? (T)Application.Current.Properties[key] : defaultValue;
        }

        private static void SetInStorage<T>(T value)
        {
            var callerName = (new StackTrace()).GetFrame(1).GetMethod().Name;
            if (!callerName.StartsWith("set_"))
            {
                throw new ArgumentException("This is not a property setter!");
            }

            var key = callerName.Substring(4);
            Application.Current.Properties[key] = value;
        }
    }
}
