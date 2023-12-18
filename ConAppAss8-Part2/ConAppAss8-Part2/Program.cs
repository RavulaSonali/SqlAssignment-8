using System;
using System.Data;

class ProductManager
{
    private DataTable productsTable;

    public ProductManager()
    {
        // Initialize the DataTable
        productsTable = new DataTable("Products");

        // Define columns
        productsTable.Columns.Add("ProductId", typeof(int));
        productsTable.Columns.Add("ProductName", typeof(string));
        productsTable.Columns.Add("ProductPrice", typeof(int));
        productsTable.Columns.Add("MnfDate", typeof(DateTime));
        productsTable.Columns.Add("ExpDate", typeof(DateTime));

        // Set Pid as the primary key
        productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["ProductId"] };
    }

    // Insert a new product
    public void InsertProduct(int ProductId, string ProductName, int ProductPrice, DateTime MnfDate, DateTime ExpDate)
    {
        DataRow newRow = productsTable.NewRow();
        newRow["ProductId"] = ProductId;
        newRow["ProductName"] = ProductName;
        newRow["ProductPrice"] = ProductPrice;
        newRow["MnfDate"] = MnfDate;
        newRow["ExpDate"] = ExpDate;

        productsTable.Rows.Add(newRow);
    }

    // Update an existing product
    public void UpdateProduct(int ProductId, string ProductName, int ProductPrice, DateTime MnfDate, DateTime ExpDate)
    {
        DataRow existingRow = productsTable.Rows.Find(ProductId);

        if (existingRow != null)
        {
            existingRow["ProductName"] = ProductName;
            existingRow["ProductPrice"] = ProductPrice;
            existingRow["MnfDate"] = MnfDate;
            existingRow["ExpDate"] = ExpDate;
        }
    }

    // Delete a product
    public void DeleteProduct(int ProductId)
    {
        DataRow rowToDelete = productsTable.Rows.Find(ProductId);

        if (rowToDelete != null)
        {
            rowToDelete.Delete();
        }
    }

    // Search for a product
    public DataRow SearchProduct(int ProductId)
    {
        return productsTable.Rows.Find(ProductId);
    }

    // Display all products
    public void DisplayAllProducts()
    {
        foreach (DataRow row in productsTable.Rows)
        {
            Console.WriteLine($"Pid: {row["ProductId"]}, PName: {row["ProductName"]}, PPrice: {row["ProductPrice"]}, MnfDate: {row["MnfDate"]}, ExpDate: {row["ExpDate"]}");
        }
    }
}

class Program
{
    static void Main()
    {
        ProductManager productManager = new ProductManager();

        productManager.InsertProduct(1, "Biscuit", 30, DateTime.Parse("2023-01-01"), DateTime.Parse("2023-12-31"));
        productManager.InsertProduct(2, "Cake", 35, DateTime.Parse("2023-02-15"), DateTime.Parse("2023-11-30"));


        // Display all products
        Console.WriteLine("All Products:");
        productManager.DisplayAllProducts();

        // Update example
        productManager.UpdateProduct(1, "Sauce", 12, DateTime.Parse("2023-03-01"), DateTime.Parse("2023-12-31"));

        // Display all products after update
        Console.WriteLine("\nAll Products After Update:");
        productManager.DisplayAllProducts();

        // Search example
        int searchProductId = 2;
        DataRow searchedProduct = productManager.SearchProduct(searchProductId);

        if (searchedProduct != null)
        {
            Console.WriteLine($"\nProduct found with Pid {searchProductId}: {searchedProduct["ProductName"]}");
        }
        else
        {
            Console.WriteLine($"\nProduct with Pid {searchProductId} not found.");
        }

        // Delete example
        int deletePid = 1;
        productManager.DeleteProduct(deletePid);

        // Display all products after delete
        Console.WriteLine("\nAll Products After Delete:");
        productManager.DisplayAllProducts();

        Console.ReadLine();
        Console.ReadKey();// Keep the console window open
    }
}