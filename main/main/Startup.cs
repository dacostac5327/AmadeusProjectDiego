using Microsoft.EntityFrameworkCore;
using shared.Models;
using shared.Services;
using AutoMapper;

namespace main
{
    public static class Startup
    {
        public static WebApplication InitApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureService(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddTransient<IEmployeeServices, EmployeeServices>();
            builder.Services.AddTransient<IDepartmentServices, DepartmentServices>();
            builder.Services.AddTransient<IARLServices, ARLServices>();
            builder.Services.AddTransient<IEPSServices, EPSServices>();
            var connection = @"Server=DESKTOP-M6664PQ\SQLEXPRESS;Database=Amadeus;Trusted_Connection=True;user id=sa;password=CristianDiaz07-";
            builder.Services.AddDbContext<AmadeusDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("main")));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
        }

        private static void Configure(WebApplication app)
        {
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

        }
    }
}
