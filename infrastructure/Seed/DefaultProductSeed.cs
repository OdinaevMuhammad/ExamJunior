using Domain.Entities;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public static class DefaultProductSeed
{
    public static void ProductSeed(DataContext context)
    {
        if(context.Products.Any()) return;
        var list = new List<Product>()
        {
            new Product(0,"Smartphone","Iphone"),
            new Product(0,"Computer","Acer"),
            new Product(0,"TV","Sony")

        };


        context.Products.AddRange(list);

        context.SaveChanges();


    }
}