
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_Client.Service.Query.Code
{
    public class ServiceStatementQuery : BaseService, IServiceStatementQuery
    {

        public async Task<List<StatementDTO>> GetStatementByQuery(string query)
        {
            List<StatementDTO> Statements = new List<StatementDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Statement/GetStatementByQuery/{query}");
                if (Res.IsSuccessStatusCode)
                {
                    string staResponse = Res.Content.ReadAsStringAsync().Result;
                    Statements = JsonConvert.DeserializeObject<List<StatementDTO>>(staResponse);
                }
                return Statements;
            }
        }

        public async Task<StatementDTO> GetStatementId(int id)
        {
            StatementDTO Statement = new StatementDTO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"Statement/GetStatementById/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    string staResponse = Res.Content.ReadAsStringAsync().Result;
                    Statement = JsonConvert.DeserializeObject<StatementDTO>(staResponse);
                }
                return Statement;
            }
        }

        public async Task<List<StatementDTO>> GetStatements()
        {
            List<StatementDTO> Statements = new List<StatementDTO>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Statement/GetStatements");

                if (Res.IsSuccessStatusCode)
                {
                    string staResponse = Res.Content.ReadAsStringAsync().Result;
                    Statements = JsonConvert.DeserializeObject<List<StatementDTO>>(staResponse);
                }

                return Statements;
            }
        }
    }
}
