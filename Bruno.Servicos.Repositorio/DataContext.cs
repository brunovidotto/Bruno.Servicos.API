using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;

namespace Bruno.Servicos.Repositorio
{
    public class DataContext : IDataContext
    {
        protected Database Database { get; set; }
        protected DbCommand Command { get; set; }
        public DataContext(Database database)
        {
            Database = database;
        }
        public void StartCommand(CommandType cmdTipo, string query)
        {
            Command = cmdTipo == CommandType.Text ? Database.GetSqlStringCommand(query) : Database.GetStoredProcCommand(query);
        }
        public void AddParameters(string paramName, object value, DbType type)
        {
            Database.AddInParameter(Command, paramName, type, value);
        }
        public void ExecuteNonQuery()
        {
            Database.ExecuteNonQuery(Command);
        }
        public IDataReader ExecuteReader()
        {
            try
            {
                var data = Database.ExecuteReader(Command);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }
        public DataSet ExecuteDataSet()
        {
            return Database.ExecuteDataSet(Command);
        }
        public T ExecuteScalar<T>()
        {
            return (T)Database.ExecuteScalar(Command);
        }
    }
}
