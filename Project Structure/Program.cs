using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace Project_Structure
{
    /// class ProductsControllers : Controller
    /// {
    ///     private ProductService _productService;
    /// 
    ///     public ProductsControllers(ProductService productService)
    ///     {
    ///         _productService = productService;
    ///     }
    /// 
    ///     // Action: baseUrl/Prodcuts/GetProduct?id = 10
    ///     public IActionResult GetProduct(int id)
    ///     {
    ///         var product = _productService.GetProductById(id);
    ///         return View(product);
    ///     }
    /// 
    /// }
    /// 
    /// class ProductService
    /// {
    ///     private ProductRepository _productRepository;
    ///     private CategoryRepository _categoryRepository;
    /// 
    ///     public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    ///     {
    ///         _productRepository = productRepository;
    ///         _categoryRepository = categoryRepository;
    ///     }
    /// 
    ///     public Product GetProductById(int id)
    ///     {
    /// 
    ///         var categories = _categoryRepository.GetAll().FindAll(c => c.IsOutOfStock == false);
    ///         var product = _productRepository.Get(id);
    /// 
    ///         if (!categories.Contains(product.Category)) return product;
    /// 
    ///         return null;
    /// 
    ///         // Business Logic
    ///     }
    /// }
    /// class ProductRepository
    /// {
    ///     private ApplicationDbContext _dbContext;
    /// 
    ///     public ProductRepository(ApplicationDbContext dbContext) // ASk CLR for creating Object from dbCOntext
    ///     {
    ///         _dbContext = dbContext;
    ///     }
    /// 
    ///     public Product Get(int id)
    ///     {
    ///         return _dbContext.Prodcuts.Find(id);
    ///     }
    /// }
    /// class CategoryRepository
    /// {
    ///     private ApplicationDbContext _dbContext;
    /// 
    ///     public CategoryRepository(ApplicationDbContext dbContext)
    ///     {
    ///         _dbContext = dbContext;
    ///     }
    /// 
    ///     public List<Category> GetAll()
    ///     {
    ///         return _dbContext.Categories.ToList();
    ///     }
    /// }
    /// class Product
    /// {
    ///     public int Id { get; set; }
    ///     public string? Name { get; set; }
    ///     public string? Description { get; set; }
    ///     public decimal Price { get; set; }
    ///     public Category Category { get; set; }
    /// }
    /// class Category
    /// {
    ///     public int Id { get; set; }
    ///     public string? Name { get; set; }
    ///     public bool IsOutOfStock { get; set; }
    /// 
    /// }
    /// class ApplicationDbContext : DbContext
    /// {
    ///     public ApplicationDbContext(DbContextOptions options) : base(options)
    ///     {
    /// 
    ///     }
    ///     public DbSet<Product> Prodcuts { get; set; }
    ///     public DbSet<Category> Categories { get; set; }
    /// 
    /// }


    public class Program
    {
        // Entry Point
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(); // Use builder Design Pattern

            #region Configure Service

            //builder.Services.AddControllers(); // Register APIs Required Services
            //                                    (Controller Activation, Model Binding, Action Filter, and etc.) To Dependance injection Container


            builder.Services.AddControllersWithViews();// Register MVC Required Services
            //                                    (Controller Activation, Model Binding, Action Filter,Views,Configuration and etc.) To Dependance injection Container

            //builder.Services.AddRazorPages();// Register MVC Required Services

            //builder.Services.AddMvc();
            #endregion


            var app = builder.Build();

            #region Configure
            /// builder.Services.AddScoped<ApplicationDbContext>(option => option.UseSqlServer("ConnectionStr"));    // use one object as long as you in the same request
            /// builder.Services.AddScoped<ProductRepository>();
            /// builder.Services.AddScoped<CategoryRepository>();
            /// builder.Services.AddScoped<ProductService>();

            app.UseRouting();

            //app.MapGet("/", () => "Hello World!");
            app.MapGet("/Home", () => "Hello Home World!");
            //app.MapGet("/About", () => "Hello About World!");
            //app.MapGet("/*", () => "Hello ***********About World!");

            app.MapPost("/Hamada", async (context) =>
            {
                await context.Response.WriteAsync("");
            });

            app.MapGet("/XX{id:int}", async (context) =>
            {
                await context.Response.WriteAsync($"Id = {context.Request.RouteValues["id"]}");
            });

            /// app.MapGet("/Movies/GetMovie/{id}", async (context) =>
            /// {
            ///     await context.Response.WriteAsync($"Id = {context.Request.RouteValues["id"]}");
            /// });

            app.MapGet("/Hamada", async (context) =>
            {
                await context.Response.WriteAsync("Hello Hamada get");
            });

            //app.MapGet("/d", async d => await d.Response.WriteAsync($"{d.User.Claims.FirstOrDefault()}"));

            app.MapGet("/test", async (context) =>
            {
                await context.Response.WriteAsync("{ a: 1 }");
            });



            /// app/*endpoint.*/.MapGet("/Rd", new RequestDelegate(async (context) =>
            /// {
            ///     await context.Response.WriteAsync("Hello Rd");
            /// }));

            app/*endpoint.*/.MapGet("/Rd", async (context) =>
            {
                await context.Response.WriteAsync("Hello Rd");
            });



            app.MapControllerRoute(
                name: "default",//        1      /   2     <== should named this specific
                                //pattern/*urlPath*/: "{controller}/{action}/{id?}"
                pattern/*urlPath*/: "{controller=Movies}/{action=Index}/{id?}"
                //defaults: new { Controller = "Movies", action = "Index" }
                //constraints: new { id = new IntRouteConstraint() }

                );


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }


            #endregion

            app.Run();

        }
        /// public void Config(IServiceCollection services)
        /// {
        ///     //services.AddTransient<ApplicationDbContext>(); // add new object for each 
        ///     //services.AddSingleton<ApplicationDbContext>(); // create object just one and it will live in heap as long as you open connection
        ///     services.AddScoped<ApplicationDbContext>(option => option.UseSqlServer("ConnectionStr"));    // use one object as long as you in the same request
        ///     services.AddScoped<ProductRepository>();
        ///     services.AddScoped<CategoryRepository>();
        ///     services.AddScoped<ProductService>();
        ///
        /// }
    }
}
