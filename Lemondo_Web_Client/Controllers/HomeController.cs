using Lemondo_Web_Client.Models;
using Lemondo_Web_Client.Service;
using Lemondo_Web_Client.Service.Command;
using Lemondo_Web_Client.Service.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IServiceStatementQuery _serviceStatementQuery;
        IServiceStatementCommand _serviceStatementCommand;

        public HomeController(
            ILogger<HomeController> logger,
            IServiceStatementQuery serviceStatementQuery,
            IServiceStatementCommand serviceStatementCommand)
        {
            _logger = logger;
            _serviceStatementCommand = serviceStatementCommand;
            _serviceStatementQuery = serviceStatementQuery;
        }

        [HttpGet("AllStatement")]
        public async Task<ActionResult> AllStatements()
        {
            var statementDTOList = await _serviceStatementQuery.GetStatements();
            var statementModelList = new List<StatementViewModel>();

            foreach (var item in statementDTOList)
            {
                string imageBase64Data = Convert.ToBase64String(item.ImageData);

                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

                statementModelList.Add(new StatementViewModel()
                {
                    Id = item.Id,
                    ImageTitle = item.ImageTitle,
                    ImageURL = imageDataURL,
                    Title = item.Title,
                    StatementDetailId = item.StatementDetailId
                });
            }

            return View(statementModelList);
        }
        [HttpGet("Detail/{id}")]
        public async Task<ActionResult> StatementDetail(int id)
        {


            var statementDTO = await _serviceStatementQuery.GetStatementId(id);

            string imageBase64Data = Convert.ToBase64String(statementDTO.ImageData);

            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            var statementModel = new StatementViewModel()
            {
                Id = statementDTO.Id,
                ImageTitle=statementDTO.ImageTitle,
                ImageURL = imageDataURL,
                StatementDetail = new StatementDetailViewModel
                {
                    Description = statementDTO.StatementDetail.Description,
                    PhoneNumber = statementDTO.StatementDetail.PhoneNumber
                }
            };
            return View(statementModel);
        }
        [HttpGet]
        public async Task<ActionResult> StatementSearch(string query)
        {
            var statementDTOList = await _serviceStatementQuery.GetStatementByQuery(query);
            var statementModelList = new List<StatementViewModel>();

            foreach (var item in statementDTOList)
            {
                string imageBase64Data = Convert.ToBase64String(item.ImageData);

                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

                statementModelList.Add(new StatementViewModel()
                {
                    Id = item.Id,
                    ImageTitle = item.ImageTitle,
                    ImageURL = imageDataURL,
                    Title = item.Title,
                    StatementDetailId = item.StatementDetailId
                });
            }

            return View(statementModelList);
        }

        public async Task<ActionResult> AddStatement(StatementDTO statementDTO)
        {
            var file = Request.Form.Files.FirstOrDefault();
            statementDTO.ImageTitle = file.FileName;

            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            statementDTO.ImageData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            var statementView = await _serviceStatementCommand.AddStatement(statementDTO);

            var statement = new StatementViewModel()
            {
                Title = statementView.Title,
                ErrrorMessage = statementView.ErrrorMessage
            };
            return View(statement);
        }
        public async Task<ActionResult> UpdateStatementApi(StatementDTO statementDTO)
        {

            var file = Request.Form.Files.FirstOrDefault();
            statementDTO.ImageTitle = file.FileName;

            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            statementDTO.ImageData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            var statementView = await _serviceStatementCommand.UpdateStatement(statementDTO);

            if (statementView.ErrrorMessage.Count == 0)
            {
                return LocalRedirect("~/AllStatement");
            }
            return Redirect($"/Home/UpdateStatement/{statementDTO.Id}");
        }

        public ActionResult DeleteStatementById(int id)
        {
            _serviceStatementCommand.DeleteStatementById(id);
            return LocalRedirect("~/AllStatement");
        }


        public IActionResult InsertStatement()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UpdateStatement(int id)
        {
            var statement = await _serviceStatementQuery.GetStatementId(id);
            return View(statement);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
