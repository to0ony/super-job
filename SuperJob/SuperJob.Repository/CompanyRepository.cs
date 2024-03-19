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

    }
}
