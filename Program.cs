using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Qcet {
  /// <summary>Program entry class.</summary>
  public class Program {
    /// <summary>Program entry method.</summary>
    public static void Main(string[] args) {
      CreateWebHostBuilder(args).Build().Run();
    }

    /// <summary>Create web host builder using Startup class.</summary>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
  }
}
