using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses_Tracker.Models.GastosModels;
using Expenses_Tracker.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expenses_Tracker.Controllers
{
    [Authorize]
    public class GastosController : Controller
    {
        private readonly IGastosRepository _gastosRepository;

        public GastosController(IGastosRepository gastosRepository)
        {
            _gastosRepository = gastosRepository;
        }

        public IActionResult Index()
        {
            var allGastos = _gastosRepository.GetAllAsync(StaticDetails.GastoAPIPath, HttpContext.Session.GetString("JWToken"));
            return View(allGastos);
        }
    }
}
