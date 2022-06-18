using Lemondo_Web_API.Data;
using Lemondo_Web_API.Domain;
using Lemondo_Web_API.Domain.Validator;
using Lemondo_Web_API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Service
{
    public class StatementService : IStatementService
    {
        DataDbContext _context;
        public StatementService(DataDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Statement>> AddStatement(Statement statement)
        {
            await _context.Statements.AddAsync(statement);

            await _context.SaveChangesAsync();

            return statement;
        }

        public async Task<ActionResult<List<Statement>>> UpdateStatement(Statement statement)
        {
            _context.Statements.Update(statement);
            _context.SaveChanges();

            var statementList = await _context.Statements.Select(x => x).ToListAsync();
            return statementList;
        }

        public async Task<ActionResult<Statement>> DeleteStatementById(int id)
        {
            var statement = await _context.Statements.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Statements.Remove(statement);
            await _context.SaveChangesAsync();

            return statement;
        }

        public async Task<Statement> GetStatementId(int id)
        {
            var statement = await (from s in _context.Statements
                                 join sd in _context.StatementDetails on s.StatementDetailId equals sd.StatementDetailId
                                 where s.Id == id
                                 select new Statement
                                 {
                                     Id = s.Id,
                                     Title = s.Title,
                                     ImageTitle = s.ImageTitle,
                                     ImageData = s.ImageData,
                                     StatementDetail = new StatementDetail
                                     {
                                         StatementDetailId = sd.StatementDetailId,
                                         Description = sd.Description,
                                         PhoneNumber = sd.PhoneNumber
                                     }
                                 }).FirstOrDefaultAsync();
            return statement;
        }


        public async Task<List<Statement>> GetStatementByQuery(string query)
        {
            var statements = (from s in _context.Statements
                              where s.Title.Contains(query)
                              select s);

            var resultStatements = await statements.ToListAsync();
            return resultStatements;
        }

        public async Task<List<Statement>> GetStatements()
        {
            var resultStatements = await _context.Statements.Select(x => x).ToListAsync();
            return resultStatements;
        }
    }
}
