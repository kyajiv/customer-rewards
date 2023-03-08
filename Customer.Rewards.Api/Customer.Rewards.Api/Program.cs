using Customer.Rewards.Api.Managers;
using Customer.Rewards.Api.Managers.Interface;
using Customer.Rewards.Api.Repository;
using Customer.Rewards.Api.Repository.Interface;

namespace Customer.Rewards.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DI - Register repository 
            builder.Services.AddTransient<ITransactionHistoryRepository, TransactionHistoryRepository>();
            builder.Services.AddTransient<ICustomerRewardsManager, CustomerRewardsManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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