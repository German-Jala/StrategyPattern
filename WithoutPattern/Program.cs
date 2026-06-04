
using WithoutPattern.Application.UseCases;
using System.Text.Json.Serialization;

namespace WithoutPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<ProcessOrderUseCase>();
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
            var app = builder.Build();
            if (app.Environment.IsDevelopment()) app.MapOpenApi();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
