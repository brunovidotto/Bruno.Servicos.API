using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Bruno.Servicos.Repositorio
{
    public class BaseRepositorio 
    {
        public IDataContext DataContext { get; set; }

        public BaseRepositorio(string stringConnection)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var database = new GenericDatabase(stringConnection, factory);
            DataContext = new DataContext(database);
        }

        public BaseRepositorio(IDataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
