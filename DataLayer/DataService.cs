using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Npgsql;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataLayer;

public class DataService
{
    public List<Category> categoryList;

    public List<Product> productList;

    public List<Order> orderList;

    public IList<Category> GetCategories()
    {

        categoryList = new List<Category>(); // To clear the list every time the function is called

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            using var cmd = new NpgsqlCommand("SELECT categoryid, categoryname, description FROM categories", connection);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                var category = new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2)
                };

                categoryList.Add(category);

            }
        }

        catch (Exception)
        {

            Console.WriteLine("Error");
        }

        return categoryList;
    }

    public Category? GetCategory(int id)
    {

        GetCategories(); // To update the categoryList

        foreach (var category in categoryList)
        {
            if (category.Id == id)
            {
                return category;
            }

        }

        return null;//_categories.FirstOrDefault(x => x.Id == id);
    }


    public Category CreateCategory(string name, string description)
    {
        GetCategories();

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            var id = categoryList.Count() + 1;

            using var cmd = new NpgsqlCommand("Insert Into categories(categoryid, categoryname, description) values( " + id + ",'" + name + "','" + description + "')", connection);
            cmd.ExecuteNonQuery();

            var category = new Category
            {
                Id = id,
                Name = name,
                Description = description
            };

            return category;

        }
        catch (Exception)
        {
        }
        return null;

    }

    public bool UpdateCategory(int id, string name, string UpdatedDescription)
    {

        GetCategories(); // To update the categoryList

        foreach (var category in categoryList)
        {
            if (category.Id == id)
            {

                var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
                using var connection = new NpgsqlConnection(connectionString);

                try
                {
                    connection.Open();
                    using var cmd = new NpgsqlCommand("UPDATE categories set categoryname = '" + name + "' , description ='" + UpdatedDescription + "' where categoryid = " + id, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch { }
            }
        }
        return false;
    }

    public bool DeleteCategory(int id)
    {
        GetCategories(); // To update the categoryList

        foreach (var category in categoryList)
        {
            if (category.Id == id)
            {

                var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
                using var connection = new NpgsqlConnection(connectionString);

                try
                {
                    connection.Open();
                    using var cmd = new NpgsqlCommand("Delete from categories where categoryid =" + id, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch { }
            }
        }
        return false;
    }

    public Product GetProduct(int id)
    {

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            using var cmd = new NpgsqlCommand("SELECT productname, categories.categoryname FROM products INNER JOIN categories ON products.categoryid = categories.categoryid WHERE productid  = " + id, connection);

            using var reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                var product = new Product
                {

                    Name = reader.GetString(0),
                    CategoryName = reader.GetString(1)

                };

                return product;

            }
        }

        catch (Exception)
        {

            Console.WriteLine("No Product Found");
        }
        return null;
    }

    public IList<Product> GetProductsByCategory(int id)
    {
        productList = new List<Product>(); // To clear the list every time the function is called

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            using var cmd = new NpgsqlCommand("SELECT productname, categories.categoryname from products INNER JOIN categories ON products.categoryid = categories.categoryid WHERE products.categoryid =" + id, connection);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                var product = new Product
                {
                    Name = reader.GetString(0),
                    CategoryName = reader.GetString(1)
                    
                };

                productList.Add(product);

            }

            return productList;
        }

        catch (Exception)
        {

            Console.WriteLine("Error");
        }


        return null;
    }

    public IList<Product> GetProductsByName(string name)
    {
        productList = new List<Product>(); // To clear the list every time the function is called

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            using var cmd = new NpgsqlCommand("SELECT productname, categories.categoryname from products INNER JOIN categories ON products.categoryid = categories.categoryid WHERE productname LIKE '%" + name + "%'", connection);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                var product = new Product
                {
                    Name = reader.GetString(0),
                    CategoryName = reader.GetString(1)

                };

                productList.Add(product);

            }

            return productList;
        }

        catch (Exception)
        {

            Console.WriteLine("Error");
        }


        return null;
    }

    public Order GetOrder(int id)
    {

        return null;
    }

    public IList<Order> GetOrders()
    {
        orderList = new List<Order>(); // To clear the list every time the function is called

        var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=*********;Database=NorthWind";
        using var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Sucess\n");

            using var cmd = new NpgsqlCommand("SELECT orderid, orderdate, requireddate, shipname, shipcity FROM orders ", connection);

            using var reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                var order = new Order
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    Required = reader.GetDateTime(2),
                    ShipName = reader.GetString(3),
                    ShipCity = reader.GetString(4)                    
                };

                orderList.Add(order);
            }

            return orderList;
        }

        catch (Exception)
        {

            Console.WriteLine("No Order Found");
        }
        return null;
    }

}
