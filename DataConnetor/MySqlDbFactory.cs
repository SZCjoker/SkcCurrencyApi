using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataConnector
{
    public class MySqlDbFactory : IDbFactory
    {
        private readonly IConfiguration _config;

        public MySqlDbFactory(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// 讀寫用資料庫
        /// </summary>
        private DbSetting _dbWriteSetting => new DbSetting
        {
            Connection = _config.GetValue<string>("storage:mysql:readWrite:connection"),
            DbProvider = _config.GetValue<string>("storage:mysql:readWrite:provider")
        };

        /// <summary>
        /// 唯讀資料庫
        /// </summary>
        private DbSetting _dbReadSetting => new DbSetting
        {
            Connection = _config.GetValue<string>("storage:mysql:readOnly:connection"),
            DbProvider = _config.GetValue<string>("storage:mysql:readOnly:provider")
        };




        public Task<MySqlConnection> CreateConnectionAsync(AccessMode policy = AccessMode.ReadOnly)
        {
            return Task.FromResult(CreateConnection(policy));
        }

       
        public MySqlConnection OpenConnection(AccessMode policy = AccessMode.ReadOnly)
        {
            var connection = CreateConnection(policy);
            connection.Open();
            return connection;
        }

       
        public async Task<MySqlConnection> OpenConnectionAsync(AccessMode policy = AccessMode.ReadOnly)
        {
            MySqlConnection connection = CreateConnection(policy);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<MySqlConnection> OpenConnectionAsync(string setting)
        {
            if (setting == null || setting == string.Empty)
                throw new InvalidOperationException();

            MySqlConnection connection = new MySqlConnection(setting);
            await connection.OpenAsync();
            return connection;
        }

        
        public MySqlConnection CreateConnection(AccessMode policy = AccessMode.ReadOnly)
        {
            switch (policy)
            {
                case AccessMode.ReadOnly:
                    return new MySqlConnection(_dbReadSetting.Connection);

                case AccessMode.ReadWrite:
                    return new MySqlConnection(_dbWriteSetting.Connection);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
