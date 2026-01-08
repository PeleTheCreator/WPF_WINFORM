
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EmployeeManager.Models;

namespace EmployeeManager.Data
{
        /// <summary>
        /// Database Helper class for all ADO.NET operations
        /// This is the Data Access Layer (DAL) - handles all database communication
        /// Uses ADO.NET for direct database access with full control
        /// PRODUCTION BEST PRACTICES:
        /// - Parameterized queries (prevents SQL injection)
        /// - Using statement (ensures proper disposal of connections)
        /// - Try-catch blocks (proper error handling)
        /// - Connection pooling (automatic with ADO.NET)
        /// - Stored procedures (better security and performance)
        /// </summary>
        public class DatabaseHelper
        {
            #region Private Fields
            // Connection string retrieved from App.config
            // Storing in config file allows changing without recompiling
            private readonly string _connectionString;
            #endregion

            #region Constructor
            /// <summary>
            /// Initialize DatabaseHelper with connection string from config
            /// </summary>
            public DatabaseHelper()
            {
                // ConnectionStrings collection comes from App.config
                // "EmployeeManagementDB" is the name we defined in App.config
                _connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagementDB"].ConnectionString;
            }
            #endregion

            #region Employee CRUD Operations

            /// <summary>
            /// Get all active employees from database
            /// Uses stored procedure for better performance and security
            /// </summary>
            /// <returns>List of employees with department information</returns>
            public List<Employee> GetAllEmployees()
            {
                var employees = new List<Employee>();

                // Using statement ensures connection is closed and disposed even if exception occurs
                // This is CRITICAL for preventing connection leaks in production
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    // SqlCommand represents a SQL query or stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", conn))
                    {
                        // Specify we're calling a stored procedure, not inline SQL
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Set timeout (in seconds) - important for long-running queries
                        cmd.CommandTimeout = 30;

                        try
                        {
                            // Open connection - expensive operation, do it once
                            conn.Open();

                            // ExecuteReader returns a forward-only, read-only cursor
                            // Most efficient way to read large result sets
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Read() advances to next row, returns false when no more rows
                                while (reader.Read())
                                {
                                    // Create Employee object and populate from database row
                                    employees.Add(new Employee
                                    {
                                        // reader["ColumnName"] gets value by column name
                                        // Cast to appropriate type
                                        EmployeeId = (int)reader["EmployeeId"],

                                        // Use .ToString() for string columns
                                        FirstName = reader["FirstName"].ToString(),
                                        LastName = reader["LastName"].ToString(),
                                        Email = reader["Email"].ToString(),

                                        // Handle nullable columns - check for DBNull
                                        Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,

                                        // Cast DateTime and Decimal appropriately
                                        HireDate = (DateTime)reader["HireDate"],
                                        Salary = (decimal)reader["Salary"],
                                        DepartmentId = (int)reader["DepartmentId"],
                                        DepartmentName = reader["DepartmentName"].ToString(),
                                        IsActive = (bool)reader["IsActive"]
                                    });
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            // Log the error in production (use logging framework like Serilog, NLog)
                            // For now, throw with additional context
                            throw new Exception($"Database error getting employees: {ex.Message}", ex);
                        }
                        catch (Exception ex)
                        {
                            // Catch any other unexpected errors
                            throw new Exception($"Error getting employees: {ex.Message}", ex);
                        }
                    }
                }

                return employees;
            }

            /// <summary>
            /// Get a single employee by ID
            /// </summary>
            /// <param name="employeeId">Employee ID to retrieve</param>
            /// <returns>Employee object or null if not found</returns>
            public Employee GetEmployeeById(int employeeId)
            {
                Employee employee = null;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameter to stored procedure
                        // Parameters prevent SQL injection attacks
                        // @EmployeeId matches parameter name in stored procedure
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                        try
                        {
                            conn.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Should only return one row
                                if (reader.Read())
                                {
                                    employee = new Employee
                                    {
                                        EmployeeId = (int)reader["EmployeeId"],
                                        FirstName = reader["FirstName"].ToString(),
                                        LastName = reader["LastName"].ToString(),
                                        Email = reader["Email"].ToString(),
                                        Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                                        HireDate = (DateTime)reader["HireDate"],
                                        Salary = (decimal)reader["Salary"],
                                        DepartmentId = (int)reader["DepartmentId"],
                                        DepartmentName = reader["DepartmentName"].ToString(),
                                        IsActive = (bool)reader["IsActive"]
                                    };
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception($"Database error getting employee: {ex.Message}", ex);
                        }
                    }
                }

                return employee;
            }

            /// <summary>
            /// Insert a new employee into database
            /// Uses OUTPUT parameter to get the newly created ID
            /// </summary>
            /// <param name="employee">Employee object to insert</param>
            /// <returns>ID of newly created employee</returns>
            public int InsertEmployee(Employee employee)
            {
                int newEmployeeId = 0;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add INPUT parameters
                        // SqlDbType specifies exact database type for better performance
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = employee.FirstName;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = employee.LastName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = employee.Email;

                        // Handle nullable Phone - use DBNull.Value if null or empty
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value =
                            string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone;

                        cmd.Parameters.Add("@HireDate", SqlDbType.Date).Value = employee.HireDate;
                        cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;
                        cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = employee.DepartmentId;

                        // Add OUTPUT parameter to get the new ID
                        // Direction.Output indicates this parameter receives a value from stored procedure
                        SqlParameter outputParam = new SqlParameter("@NewEmployeeId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        try
                        {
                            conn.Open();

                            // ExecuteNonQuery returns number of rows affected
                            // Used for INSERT, UPDATE, DELETE (not SELECT)
                            cmd.ExecuteNonQuery();

                            // Retrieve the output parameter value
                            newEmployeeId = (int)outputParam.Value;
                        }
                        catch (SqlException ex)
                        {
                            // Check for specific SQL errors
                            if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                            {
                                throw new Exception("Email already exists in the system.", ex);
                            }
                            throw new Exception($"Database error inserting employee: {ex.Message}", ex);
                        }
                    }
                }

                return newEmployeeId;
            }

            /// <summary>
            /// Update existing employee in database
            /// </summary>
            /// <param name="employee">Employee object with updated values</param>
            /// <returns>True if update successful</returns>
            public bool UpdateEmployee(Employee employee)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add all parameters
                        cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone);
                        cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                        try
                        {
                            conn.Open();

                            // ExecuteNonQuery returns number of rows affected
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // If 1 row affected, update was successful
                            return rowsAffected > 0;
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627 || ex.Number == 2601)
                            {
                                throw new Exception("Email already exists in the system.", ex);
                            }
                            throw new Exception($"Database error updating employee: {ex.Message}", ex);
                        }
                    }
                }
            }

            /// <summary>
            /// Soft delete an employee (sets IsActive to false)
            /// Soft delete is better than hard delete for audit trails
            /// </summary>
            /// <param name="employeeId">ID of employee to delete</param>
            /// <returns>True if delete successful</returns>
            public bool DeleteEmployee(int employeeId)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                        try
                        {
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception($"Database error deleting employee: {ex.Message}", ex);
                        }
                    }
                }
            }

            /// <summary>
            /// Search employees by name, email, or department
            /// Demonstrates dynamic search functionality
            /// </summary>
            /// <param name="searchTerm">Term to search for</param>
            /// <returns>List of matching employees</returns>
            public List<Employee> SearchEmployees(string searchTerm)
            {
                var employees = new List<Employee>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchEmployees", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchTerm", searchTerm ?? string.Empty);

                        try
                        {
                            conn.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    employees.Add(new Employee
                                    {
                                        EmployeeId = (int)reader["EmployeeId"],
                                        FirstName = reader["FirstName"].ToString(),
                                        LastName = reader["LastName"].ToString(),
                                        Email = reader["Email"].ToString(),
                                        Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                                        HireDate = (DateTime)reader["HireDate"],
                                        Salary = (decimal)reader["Salary"],
                                        DepartmentId = (int)reader["DepartmentId"],
                                        DepartmentName = reader["DepartmentName"].ToString()
                                    });
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception($"Database error searching employees: {ex.Message}", ex);
                        }
                    }
                }

                return employees;
            }

            #endregion

            #region Department Operations

            /// <summary>
            /// Get all active departments
            /// Used to populate dropdown lists in UI
            /// </summary>
            /// <returns>List of departments</returns>
            public List<Department> GetAllDepartments()
            {
                var departments = new List<Department>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllDepartments", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            conn.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    departments.Add(new Department
                                    {
                                        DepartmentId = (int)reader["DepartmentId"],
                                        DepartmentName = reader["DepartmentName"].ToString(),
                                        Description = reader["Description"] != DBNull.Value ?
                                            reader["Description"].ToString() : string.Empty,
                                        IsActive = (bool)reader["IsActive"]
                                    });
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception($"Database error getting departments: {ex.Message}", ex);
                        }
                    }
                }

                return departments;
            }

            #endregion

            #region Connection Test

            /// <summary>
            /// Test database connection
            /// Useful for application startup validation
            /// </summary>
            /// <returns>True if connection successful</returns>
            public bool TestConnection()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            #endregion
        }
    }
