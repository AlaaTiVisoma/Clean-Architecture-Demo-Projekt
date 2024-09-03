
using BookStore.Application.Mapping;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.Interfaces;
using BookStore.Application.UseCases;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.Core.Interfaces.Visoma3.BookStore.Core.Interfaces;
using BookStore.Core.Interfaces.Visoma3;
using BookStore.Infrastructure.Data.Repositories.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using BookStore.Application.Services.Visoma3;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region MongoDB Configuration

            // Configure and bind MongoDB settings
            builder.Services.Configure<VisomaTicketMongoDbSettings>(
                builder.Configuration.GetSection("VisomaTicketDbSettings"));

            // Register the VisomaTicketDbContext with settings from configuration
            builder.Services.AddSingleton<VisomaTicketDbContext>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<VisomaTicketMongoDbSettings>>().Value;
                return new VisomaTicketDbContext(settings.ConnectionString, settings.DatabaseName);
            });

            // Register MongoDB repositories
            builder.Services.AddScoped<IControlRepository, ControlRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketDataRepository, TicketDataRepository>();

            // Register MongoDB services
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITicketDataService, TicketDataService>();
            builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();

            #endregion

            #region SQL Server Configuration

            // Configure DbContext for SQL Server
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDatabase")));

            // Register SQL Server repositories
           
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Register SQL Server services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

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

        /*
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region VisomaTicket
          
            // Configure and bind MongoDB settings
            builder.Services.Configure<VisomaTicketMongoDbSettings>(
                builder.Configuration.GetSection("VisomaTicketDbSettings"));

            // Register the VisomaTicketDbContext with settings from configuration
            builder.Services.AddSingleton<VisomaTicketDbContext>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<VisomaTicketMongoDbSettings>>().Value;
                return new VisomaTicketDbContext(settings.ConnectionString, settings.DatabaseName);
            });
            
         // Register the repositories
         builder.Services.AddScoped<IControlRepository, ControlRepository>();
            
         builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
         builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
         builder.Services.AddScoped<ITicketRepository, TicketRepository>();
         builder.Services.AddScoped<ITicketDataRepository, TicketDataRepository>();
         // Register services and repositories
         builder.Services.AddScoped<ITicketService, TicketService>();
         builder.Services.AddScoped<ITicketDataService, TicketDataService>();
         builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
          


            #endregion

            #region Adding
            
            // Load MongoDB settings from configuration
            var mongoDbSettings = builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection("MongoDbSettings"));

            builder.Services.AddSingleton<MongoDbContext>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoDbContext(settings.ConnectionString, settings.DatabaseName);
            });
            

            // Configure DbContext
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDatabase")));
            

            // Register repositories
            builder.Services.AddScoped<IBookRepositoryMongo, BookRepositoryMongo>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


            // Register services
            builder.Services.AddScoped<IBookServiceMongo, BookServiceMongo>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

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
        */
    }
}
