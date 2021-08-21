using DevelopmentTrials.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevelopmentTrials.DataAccessLayer.Services.DatabaseServices
{
    public class SqlService : ISqlService
    {
        private readonly IConfiguration _configuration;

        public SqlService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ExecuteCommand(string commandText)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteReader(string commandText)
        {
            throw new NotImplementedException();
        }
    }
}
