
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaGoAPI.DataAccess.Interfaces;
using PizzaGoAPI.DataAccess.Repositories;
using PizzaGoAPI.DBContext;
using PizzaGoAPI.Entities;
using PizzaGoAPI.Services.Authorization;
using PizzaGoAPI.Services.MailServece;
using System.Text;

namespace PizzaGoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson();


            /*AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore);*/

            //ƒобавим аутентификацию с помощью jwt-токена и авторизацию
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
            var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
            options.TokenValidationParameters=new TokenValidationParameters
            {
                ValidateIssuer=true,
                ValidIssuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value,
                ValidateAudience=true,
                ValidAudience= builder.Configuration.GetSection("JWTSettings:Audience").Value,
                ValidateLifetime=true,
                IssuerSigningKey=signingKey,
                ValidateIssuerSigningKey=true
            });

            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // регистраци€ контекста базы данных
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<PizzaAppContext>(options => options.UseSqlServer(connectionString));
            //регистраци€ репозиториев
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //регистраци€ автомаппера
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //регистраци€ сендера
#if DEBUG
            builder.Services.AddScoped<IMailService,LocalMailService>();
#else
            builder.Services.AddScoped<IMailService,CloudMailService>();
#endif
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.MapControllers();
            

            app.Run();
        }
    }
}