
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EmployeeManager.Models;

namespace EmployeeManager.Data
{
        public interface IDatabaseService
        {
            Task<List<Employees>> GetAllEmployeesAsync();
            Task<Employees> GetEmployeeByIdAsync(int employeeId);
            Task<int> InsertEmployeeAsync(Employees employee);
            Task<bool> UpdateEmployeeAsync(Employees employee);
            Task<bool> DeleteEmployeeAsync(int employeeId);
            Task<List<Employees>> SearchEmployeesAsync(string searchTerm);

            Task<List<Department>> GetAllDepartmentsAsync();

            Task<bool> TestConnectionAsync();
        }
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

    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagementDB"].ConnectionString;
        }

        #region Employee CRUD Operations

        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            var employees = new List<Employees>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30;

                    try
                    {
                        await conn.OpenAsync();

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                employees.Add(new Employees
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
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error getting employees: {ex.Message}", ex);
                    }
                }
            }

            return employees;
        }

        public async Task<Employees> GetEmployeeByIdAsync(int employeeId)
        {
            Employees employee = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                    try
                    {
                        await conn.OpenAsync();

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                employee = new Employees
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
                    catch (Exception ex)
                    {
                        throw new Exception($"Error getting employee: {ex.Message}", ex);
                    }
                }
            }

            return employee;
        }

        public async Task<int> InsertEmployeeAsync(Employees employee)
        {
            int newEmployeeId = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = employee.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = employee.LastName;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = employee.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value =
                        string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone;
                    cmd.Parameters.Add("@HireDate", SqlDbType.Date).Value = employee.HireDate;
                    cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;
                    cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = employee.DepartmentId;

                    SqlParameter outputParam = new SqlParameter("@NewEmployeeId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        newEmployeeId = (int)outputParam.Value;
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        throw new Exception("Email already exists in the system.", ex);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error inserting employee: {ex.Message}", ex);
                    }
                }
            }

            return newEmployeeId;
        }

        public async Task<bool> UpdateEmployeeAsync(Employees employee)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone);
                    cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        throw new Exception("Email already exists in the system.", ex);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error updating employee: {ex.Message}", ex);
                    }
                }
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error deleting employee: {ex.Message}", ex);
                    }
                }
            }
        }

        public async Task<List<Employees>> SearchEmployeesAsync(string searchTerm)
        {
            var employees = new List<Employees>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SearchEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm ?? string.Empty);

                    try
                    {
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                employees.Add(new Employees
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
                    catch (Exception ex)
                    {
                        throw new Exception($"Error searching employees: {ex.Message}", ex);
                    }
                }
            }

            return employees;
        }

        #endregion

        #region Department Operations

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var departments = new List<Department>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllDepartments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                departments.Add(new Department
                                {
                                    DepartmentId = (int)reader["DepartmentId"],
                                    DepartmentName = reader["DepartmentName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                    IsActive = (bool)reader["IsActive"]
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error getting departments: {ex.Message}", ex);
                    }
                }
            }

            return departments;
        }

        #endregion

        #region Connection Test

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
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



