using Customer.Rewards.Api.Exceptions.Filters;
using Customer.Rewards.Api.Managers;
using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Repository;
using Customer.Rewards.Api.Repository.Interface;
using System.Reflection;

namespace Customer.Rewards.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // register filters
            builder.Services.AddControllers(options => options.Filters.Add<InvalidCustomerIdExceptionFilterAttribute>());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // DI - Register repository 
            builder.Services.AddTransient<ITransactionHistoryRepository, TransactionHistoryRepository>();
            builder.Services.AddTransient<ICustomerRewardsManager, CustomerRewardsManager>();

            var app = builder.Build();

            // commenting out to make swagger available from docker
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}