using System.Collections.Generic;
using System;

namespace PatientPortalBackend.Utils
{
    public sealed class ConnectionStringProperties
    {
        private static readonly Lazy<ConnectionStringProperties> Instance =
            new Lazy<ConnectionStringProperties>(() => new ConnectionStringProperties());

        private static readonly Dictionary<string, string> _connectionStringDict = new Dictionary<string, string>();

        private ConnectionStringProperties()
        {
        }

        public static ConnectionStringProperties GetInstance => Instance.Value;

        public void AddConnectionString(string name, string connectionString)
        {
            if (!_connectionStringDict.ContainsKey(name))
            {
                try
                {
                    _connectionStringDict.Add(name, connectionString);
                }
                catch (ArgumentException)
                {
                }
            }
        }

        public string GetConnectionString(string name)
        {
            return _connectionStringDict[name];
        }
    }
}
