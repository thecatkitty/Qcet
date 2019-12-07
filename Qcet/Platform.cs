namespace Qcet
{
    public static class Platform
    {
        public static PlatformProvider Provider { get; set; } = new PlatformProvider();

        public static string Version { get => Provider.Version; }
        public static string Manufacturer { get => Provider.Manufacturer; }
        public static string Model {  get => Provider.Model; }
    }
}
