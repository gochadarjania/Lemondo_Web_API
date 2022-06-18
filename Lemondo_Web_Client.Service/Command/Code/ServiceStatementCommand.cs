using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_Client.Service.Command.Code
{
    public class ServiceStatementCommand : BaseService, IServiceStatementCommand
    {
        public async Task<StatementDTO> AddStatement(StatementDTO statement)
        {
            StatementDTO ReturnStatement = new StatementDTO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string jsonstring = JsonConvert.SerializeObject(statement);
                var data = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync($"Statement/AddStatement/", data);

                if (Res.IsSuccessStatusCode)
                {
                    string staResponse = Res.Content.ReadAsStringAsync().Result;
                    ReturnStatement = JsonConvert.DeserializeObject<StatementDTO>(staResponse);
                    return ReturnStatement;
                }

                ReturnStatement.ErrrorMessage = JsonConvert.DeserializeObject<List<string>>(Res.Content.ReadAsStringAsync().Result);

                return ReturnStatement;
            }
        }

        public async void DeleteStatementById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync($"Statement/DeleteStatementById/{id}");
            }
        }

        public async Task<StatementDTO> UpdateStatement(StatementDTO statement)
        {
            StatementDTO ReturnStatement = new StatementDTO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string jsonstring = JsonConvert.SerializeObject(statement);
                var data = new StringContent(jsonstring, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PutAsync($"Statement/UpdateStatement/", data);

                if (Res.IsSuccessStatusCode)
                {
                    string staResponse = Res.Content.ReadAsStringAsync().Result;
                    ReturnStatement = JsonConvert.DeserializeObject<StatementDTO>(staResponse);
                    return ReturnStatement;
                }

                ReturnStatement.ErrrorMessage = JsonConvert.DeserializeObject<List<string>>(Res.Content.ReadAsStringAsync().Result);

                return ReturnStatement;
            }

        }
    }
}
