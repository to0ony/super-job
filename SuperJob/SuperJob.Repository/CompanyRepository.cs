using SuperJob.Model;
using SuperJob.Repository.Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SuperJob.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            List<Company> companies = new List<Company>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM company";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Company company = new Company
                            {
                                CompanyId = reader.GetGuid(reader.GetOrdinal("companyid")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Address = reader.GetString(reader.GetOrdinal("address")),
                                EmailAddress = reader.GetString(reader.GetOrdinal("emailaddress")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("creationdate")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("isactive")),
                                OwnerId = reader.GetGuid(reader.GetOrdinal("ownerid"))
                            };

                            companies.Add(company);
                        }
                    }
                }
            }

            return companies;
        }

        public async Task<Company> GetByIdAsync(Guid companyId)
        {
            Company company = new Company();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM company WHERE companyid = @companyId";
                //chech if there is a company with the given id, if there is such company, get it and return it
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@companyId", companyId);

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            company = new Company
                            {
                                CompanyId = reader.GetGuid(reader.GetOrdinal("companyid")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Address = reader.GetString(reader.GetOrdinal("address")),
                                EmailAddress = reader.GetString(reader.GetOrdinal("emailaddress")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("creationdate")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("isactive")),
                                OwnerId = reader.GetGuid(reader.GetOrdinal("ownerid"))
                            };
                        }
                    }
                }
                return company;
            }
        }

        public async Task<bool> CreateAsync(Company company)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO company (companyid, name, description, address, emailaddress, phonenumber, creationdate, isactive, ownerid) VALUES (@CompanyId, @Name, @Description, @Address, @EmailAddress, @PhoneNumber, @CreationDate, @IsActive, @OwnerId)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", Guid.NewGuid());
                    command.Parameters.AddWithValue("@Name", company.Name);
                    command.Parameters.AddWithValue("@Description", company.Description);
                    command.Parameters.AddWithValue("@Address", company.Address);
                    command.Parameters.AddWithValue("@EmailAddress", company.EmailAddress);
                    command.Parameters.AddWithValue("@PhoneNumber", company.PhoneNumber);
                    command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", true);
                    command.Parameters.AddWithValue("@OwnerId", company.OwnerId);

                    int result = await command.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(Guid companyId, Company updatedCompany)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE company SET ";

                if (!string.IsNullOrEmpty(updatedCompany.Name))
                {
                    query += "name = @Name, ";
                }
                if (!string.IsNullOrEmpty(updatedCompany.Description))
                {
                    query += "description = @Description, ";
                }
                if (!string.IsNullOrEmpty(updatedCompany.Address))
                {
                    query += "address = @Address, ";
                }
                if (!string.IsNullOrEmpty(updatedCompany.EmailAddress))
                {
                    query += "emailaddress = @EmailAddress, ";
                }
                if (!string.IsNullOrEmpty(updatedCompany.PhoneNumber))
                {
                    query += "phonenumber = @PhoneNumber, ";
                }

                // Uklonite zadnji zarez i razmak iz upita
                query = query.TrimEnd(',', ' ');

                query += " WHERE companyid = @CompanyId";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    if (!string.IsNullOrEmpty(updatedCompany.Name))
                    {
                        command.Parameters.AddWithValue("@Name", updatedCompany.Name);
                    }
                    if (!string.IsNullOrEmpty(updatedCompany.Description))
                    {
                        command.Parameters.AddWithValue("@Description", updatedCompany.Description);
                    }
                    if (!string.IsNullOrEmpty(updatedCompany.Address))
                    {
                        command.Parameters.AddWithValue("@Address", updatedCompany.Address);
                    }
                    if (!string.IsNullOrEmpty(updatedCompany.EmailAddress))
                    {
                        command.Parameters.AddWithValue("@EmailAddress", updatedCompany.EmailAddress);
                    }
                    if (!string.IsNullOrEmpty(updatedCompany.PhoneNumber))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", updatedCompany.PhoneNumber);
                    }

                    int result = await command.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }
    }
}
