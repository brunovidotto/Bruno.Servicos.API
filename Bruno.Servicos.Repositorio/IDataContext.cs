using System.Data;

namespace Bruno.Servicos.Repositorio
{
    public interface IDataContext
    {
        void StartCommand(CommandType cmdTipo, string query);

        void AddParameters(string paramName, object value, DbType type);

        void ExecuteNonQuery();

        IDataReader ExecuteReader();

        T ExecuteScalar<T>();

        DataSet ExecuteDataSet();
    }
}
