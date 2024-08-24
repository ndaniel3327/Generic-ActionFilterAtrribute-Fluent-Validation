
using BookzoneProjNituDaniel.Data;
using BookzoneProjNituDaniel.Models.Input.Order;
using BookzoneProjNituDaniel.Models.Input.Product;
using BookzoneProjNituDaniel.Models.Validators.Order;
using BookzoneProjNituDaniel.Models.Validators.Product;
using BookzoneProjNituDaniel.Repositories.Contracts;
using BookzoneProjNituDaniel.Repositories.Implementations;
using BookzoneProjNituDaniel.Repositories.Validation;
using BookzoneProjNituDaniel.Services.Contracts;
using BookzoneProjNituDaniel.Services.Implementations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace BookzoneProjNituDaniel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IValidationRepository,ValidationRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IValidator<CreateProductInput>, CreateProductValidator>();
            builder.Services.AddScoped<IValidator<UpdateProductInput>, UpdateProductValidator>();

            builder.Services.AddScoped<IValidator<CreateOrderInput>, CreateOrderValidator>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
