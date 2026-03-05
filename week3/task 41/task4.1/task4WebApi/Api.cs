using AutoMapper;
using task4Services.Mapper;
using task4Services.RepositoryService;
using task4ModelBase.Repository;
using task4ModelBase.Database;
using task4ModelBase.Models;
using task4ModelBase.Database.DbManager;
using task4Services.DbManager;

namespace task4WebApi
{
    public class Api
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<DbManagerService>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
