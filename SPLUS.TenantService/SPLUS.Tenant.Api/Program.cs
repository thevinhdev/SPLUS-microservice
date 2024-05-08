

//using Infrastructure.Extensions;
using SPLUS.Tenant.Api;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

////builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
//builder.Services.AddTransient<ITenantService, TenantService>();
//builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));
//builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

////builder.Services.AddJwtAuthentication();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();


namespace SPLUS.Tenant.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}