using AndelaTest.Core;
using AndelaTest.Data;
using AndelaTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AndelaTest"));
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("api/v1/merchants", async(IMerchantRepository merchantRepository) =>
{
    var merchants = await merchantRepository.GetAllMerchants();
    return Results.Ok(merchants);
});

app.MapGet("api/v1/products", async(IProductRepository productRepository) =>
{
    var products = await productRepository.GetAllProduct();
    return Results.Ok(products);
});

app.MapPost("api/v1/creatproduct", async(Product product, IProductRepository productRepository ) =>
{
    await productRepository.CreateProduct(product);
    await productRepository.SaveAsync();
    return Results.Created($"/todoitems/{product.Id}",product);
});

app.MapGet("api/v1/getProductById/{id}", async(int id, IProductRepository productRepository ) =>
{
    var product = await productRepository.GetProductById(id);

    if(product == null)
     return Results.NotFound();

    return Results.Created($"/todoitems/{product.Id}",product);
});

app.Run();
