using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesTracker.Services.Services;
using ExpensesTrackerAPI.Resources;
using ExpensesTrackerCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {

        private readonly IGastoService _gastoService;
        private readonly IMapper _mapper;

        public GastosController(IGastoService musicService, IMapper mapper)
        {
            _gastoService = musicService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<GastoResource>>> GetAllGastos()
        {
            var gastos = await _gastoService.GetAllGastos();
            var gastosResources = _mapper.Map<IEnumerable<Gasto>, IEnumerable<GastoResource>>(gastos);

            return Ok(gastosResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GastoResource>>> GetGastoById(Guid id)
        {
            var gasto = await _gastoService.GetGastoById(id);
            var gastoResources = _mapper.Map<Gasto, GastoResource>(gasto);

            return Ok(gastoResources);
        }
    }
}
