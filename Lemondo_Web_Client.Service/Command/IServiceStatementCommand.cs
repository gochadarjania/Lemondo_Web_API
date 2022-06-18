using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_Client.Service.Command
{
    public interface IServiceStatementCommand
    {
        Task<StatementDTO> AddStatement(StatementDTO statement);
        Task<StatementDTO> UpdateStatement(StatementDTO statement);
        void DeleteStatementById(int id);
    }
}
