using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace NorthwindCustomersByCity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection string to connect to SQL Server and Northwind database
            string connectionString = "Data Source=LAPTOP-DU6SRIJM;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;";

            try
            {
                // Get all unique cities from the Customers table
                List<string> cities = GetUniqueCities(connectionString);

                // Display all available cities to guide the user
                Console.WriteLine("Available cities:");
                Console.WriteLine(string.Join(", ", cities));
                Console.WriteLine();

                // Ask user to enter a city
                Console.Write("Enter the name of a city: ");
                string? city = Console.ReadLine();

                // Check if user input is empty or null
                if (string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine("You did not enter a city.");
                    return;
                }

                 // Get all company names from the selected city
                List<string> companies = GetCompaniesByCity(connectionString, city);

                Console.WriteLine();

                // If companies are found, display them
                if (companies.Count > 0)
                {
                    Console.WriteLine($"There are {companies.Count} customers in {city}:");
                    foreach (string company in companies)
                    {
                        Console.WriteLine(company);
                    }
                }
                else
                {
                    // If no customers found in that city
                    Console.WriteLine($"There are no customers in {city}.");
                }
            }
            catch (Exception ex)
            {
                // Catch any runtime errors (database, connection, etc.)
                Console.WriteLine("Something went wrong.");
                Console.WriteLine(ex.Message);
            }
        }

        // Method to get all unique cities from Customers table
        static List<string> GetUniqueCities(string connectionString)
        {
            // Create a list to store city names
            List<string> cities = new List<string>();

            // Create SQL connection using connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                // SQL query to get distinct (unique) cities
                string sql = @"SELECT DISTINCT City
                               FROM Customers
                               WHERE City IS NOT NULL
                               ORDER BY City";

                // Create SQL command
                using (SqlCommand command = new SqlCommand(sql, connection))
                // Execute query and read results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through each row returned
                    while (reader.Read())
                    {
                        // Add city to list
                        cities.Add(reader["City"].ToString()!);
                    }
                }
            }
            
            // Return list of cities
            return cities;
        }
        
        // Method to get company names based on selected city
        static List<string> GetCompaniesByCity(string connectionString, string city)
        {
            // Create a list to store company names
            List<string> companies = new List<string>();

            // Create SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open connection
                connection.Open();

                // SQL query with parameter to avoid SQL injection
                string sql = @"SELECT CompanyName
                               FROM Customers
                               WHERE City = @City
                               ORDER BY CompanyName";

                // Create SQL command
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Add parameter value safely
                    command.Parameters.AddWithValue("@City", city);
                    
                    // Execute query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through results
                        while (reader.Read())
                        {
                            // Add company name to list
                            companies.Add(reader["CompanyName"].ToString()!);
                        }
                    }
                }
            }
            // Return list of company names
            return companies;
        }
    }
}