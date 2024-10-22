using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {
        IList<Category> GetCategories();

        Category? GetCategory(int id);
        Category CreateCategory(string name, string description);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        IList<Category> GetCategoriesByName(string name);



        Product? GetProduct(int id);
        Product? GetProductsByCategory(int id);
        IList<Product> GetProductByName(string search);


        Order? GetOrder(int id);

        IList<Order> GetOrders();

        //IList<Product> GetProducts();
        
        



    }
}