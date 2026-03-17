using Microsoft.EntityFrameworkCore;
using task4ModelBase.Database;
using task4ModelBase.Repository;
using task4Services.Mapper;
using task4Services.RepositoryService;
using task4Services.Validator;

namespace task4WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataBaseConnection>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(cfg => { }, 
                typeof(MapperProfile).Assembly);

            builder.Services.AddScoped<AuthorRepository>();
            builder.Services.AddScoped<BookRepository>();

            builder.Services.AddScoped<AuthorValidator>();
            builder.Services.AddScoped<BookValidator>();


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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
