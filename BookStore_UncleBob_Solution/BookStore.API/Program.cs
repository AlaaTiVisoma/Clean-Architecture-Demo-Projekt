
using BookStore.Application.Mapping;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.Interfaces;
using BookStore.Application.UseCases;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Adding
            // Configure DbContext
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDatabase")));


            // Register repositories
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            // Register services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();

            // Register Use Cases
            builder.Services.AddScoped<GetAllBooksUseCase>();
            builder.Services.AddScoped<GetBookByIdUseCase>();
            builder.Services.AddScoped<AddBookUseCase>();
            builder.Services.AddScoped<UpdateBookUseCase>();
            builder.Services.AddScoped<DeleteBookUseCase>();
            builder.Services.AddScoped<GetBookSummaryUseCase>();

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));




            #endregion


            // Add services to the container.

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
