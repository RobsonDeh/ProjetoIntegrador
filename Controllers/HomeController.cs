using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjetoInt03_Robson.Models;

namespace ProjetoInt03_Robson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ContactRepository ur = new ContactRepository();
            ur.TestarConexao();
            return View();
        }

        public IActionResult Quemsomos()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult TratamentoNaturais()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contact novoUser)
        {
            ContactRepository ur = new ContactRepository();
            ur.inserir(novoUser);

            return View("Confirmacao");
        }

        public IActionResult Confirmacao ()
        {
            ViewData["mensagem"] = "Pergunta feita com sucesso!";
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
