using Lemondo_Web_API.Domain;
using Lemondo_Web_API.Domain.Validator;
using Lemondo_Web_API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : Controller
    {
        private IStatementService _statmentService;
        public StatementController(IStatementService statmentService)
        {
            _statmentService = statmentService;
        }
        [HttpPost("AddStatement")]
        public async Task<ActionResult> AddStatement(Statement statement)
        {
            var errors = Validator(statement);

            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }

            await _statmentService.AddStatement(statement);

            return Ok(statement);
        }

        [HttpPut("UpdateStatement")]
        public async Task<ActionResult<Statement>> UpdateStatement(Statement statement)
        {
            var errors = Validator(statement);

            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }

            return Ok(await _statmentService.UpdateStatement(statement));
        }

        [HttpDelete("DeleteStatementById/{id}")]
        public async Task<ActionResult<Statement>> DeleteStatementById(int id)
        {
             return await _statmentService.DeleteStatementById(id);
        }

        [HttpGet("GetStatements")]
        public async Task<List<Statement>> GetStatements()
        {
            var person = await _statmentService.GetStatements();
            return person;
        }

        [HttpGet("GetStatementById/{id}")]
        public async Task<Statement> GetStatementById(int id)
        {
            var person = await _statmentService.GetStatementId(id);
            return person;
        }

        [HttpGet("GetStatementByQuery/{query}")]
        public async Task<List<Statement>> GetStatementByQuery(string query)
        {
            var resultPersons = await _statmentService.GetStatementByQuery(query);
            return resultPersons;
        }
        private List<string> Validator(Statement statement)
        {

            var errors = new List<string>();
            var validator = new StatementValidator();
            var results = validator.Validate(statement);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
