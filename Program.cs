using Microsoft.Extensions.FileProviders;
using WebShare.Hubs;

namespace WebShare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "BrowserExtension")),
                RequestPath = "/BrowserExtension",
                EnableDefaultFiles = true
            });

            app.MapControllers();
            app.MapHub<ShareHub>("/sharehub");

            app.Run();
        }
    }
}