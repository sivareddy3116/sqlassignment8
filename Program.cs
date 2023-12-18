using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppAssignment
{
    class Program
    {
        private const string ConnectionString = "Server=DESKTOP-EBTO5CT;Database=Day8assDb;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            // Part 1: Display top 5 records from the "Products" table
            DisplayTop5Products();

            // Part 2: In-memory operations using DataTable
            DataTableOperations();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DisplayTop5Products()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT TOP 5 * FROM Products ORDER BY PName DESC";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Top 5 Products in Descending Order of PName:");
                        Console.WriteLine("----------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"PId: {reader["PId"]}, PName: {reader["PName"]}, PPrice: {reader["PPrice"]}, MnfDate: {reader["MnfDate"]}, ExpDate: {reader["ExpDate"]}");
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        static void DataTableOperations()
        {
            // Creating a DataTable with the same structure as the "Products" table
            DataTable productsTable = new DataTable("Products");
            productsTable.Columns.Add("PId", typeof(string));
            productsTable.Columns.Add("PName", typeof(string));
            productsTable.Columns.Add("PPrice", typeof(decimal));
            productsTable.Columns.Add("MnfDate", typeof(DateTime));
            productsTable.Columns.Add("ExpDate", typeof(DateTime));

            // Define the primary key for the DataTable
            productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["PId"] };

            // Part 2A: Insert into DataTable
            productsTable.Rows.Add("P00011", "SampleProduct1", 19.99, DateTime.Now, DateTime.Now.AddMonths(6));
            productsTable.Rows.Add("P00012", "SampleProduct2", 29.99, DateTime.Now, DateTime.Now.AddMonths(9));

            // Part 2B: Update in DataTable
            DataRow rowToUpdate = productsTable.Rows.Find("P00011");
            if (rowToUpdate != null)
            {
                rowToUpdate["PPrice"] = 24.99;
            }

            // Part 2C: Delete from DataTable
            DataRow rowToDelete = productsTable.Rows.Find("P00012");
            if (rowToDelete != null)
            {
                rowToDelete.Delete();
            }

            // Part 2D: Search in DataTable
            DataRow[] searchResults = productsTable.Select("PName LIKE 'SampleProduct%'");
            Console.WriteLine("Search Results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"PId: {result["PId"]}, PName: {result["PName"]}, PPrice: {result["PPrice"]}");
            }
        }
    }
}
