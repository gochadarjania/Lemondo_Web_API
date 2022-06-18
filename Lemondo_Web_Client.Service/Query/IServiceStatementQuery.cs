using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_Client.Service.Query
{
    public interface IServiceStatementQuery
    {
        Task<List<StatementDTO>> GetStatements();
        Task<StatementDTO> GetStatementId(int id);
        Task<List<StatementDTO>> GetStatementByQuery(string query);
    }
}
