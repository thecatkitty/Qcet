using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qcet.Models;

namespace Qcet {
  /// <summary>Middleware configuration class.</summary>
  public class Startup {
    /// <summary>Constructor.</summary>
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    /// <summary>Configuration variables.</summary>
    public IConfiguration Configuration { get; }

    /// <summary>Services configuration method.</summary>
    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<QcetContext>(opt => opt.UseInMemoryDatabase("Qcet"));
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
          Title = "Qcet API",
          Version = "v1"
        });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    /// <summary>HTTP pipeline configuration method.</summary>
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseHsts();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c => {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Qcet API v1");
      });

      //app.UseHttpsRedirection();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}
