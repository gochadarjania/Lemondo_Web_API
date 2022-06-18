using Lemondo_Web_API.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Service.Interface
{
    public interface IStatementService
    {
        Task<ActionResult<Statement>> AddStatement(Statement statement);
        Task<ActionResult<List<Statement>>> UpdateStatement(Statement statement);
        Task<ActionResult<Statement>> DeleteStatementById(int id);

        Task<List<Statement>> GetStatements();
        Task<Statement> GetStatementId(int id);
        Task<List<Statement>> GetStatementByQuery(string query);

    }
}
