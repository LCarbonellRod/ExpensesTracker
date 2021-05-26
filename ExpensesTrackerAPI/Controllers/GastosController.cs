using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesTracker.Services.Services;
using ExpensesTrackerAPI.Resources;
using ExpensesTrackerAPI.Validators;
using ExpensesTrackerCore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTrackerAPI.Controllers
{

    //[Authorize("OnlyTest")] if I would like to authorize using policies too, i should add this.

    [Route("api/gastos")]
    [ApiController]
    // Add this when DefaultScheme is added
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
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

        [HttpPost("")]
        public async Task<ActionResult<GastoResource>> CreateGasto([FromBody] SaveGastoResource saveGastoResource)
        {
            var validator = new SaveGastoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveGastoResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var gastoToCreate = _mapper.Map<SaveGastoResource, Gasto>(saveGastoResource);

            var newGasto = await _gastoService.CreateGasto(gastoToCreate);

            var gasto = await _gastoService.GetGastoById(newGasto.Id);

            var gastoResource = _mapper.Map<Gasto, GastoResource>(gasto);

            return Ok(gastoResource);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GastoResource>> UpdateGasto(Guid id, [FromBody] SaveGastoResource saveGastoResource)
        {
            var validator = new SaveGastoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveGastoResource);


            var requestIsInvalid = id == null || !validationResult.IsValid;

            if (requestIsInvalid)
            {
                return BadRequest(validationResult.Errors);
            }

            var gastoToBeUpdated = await _gastoService.GetGastoById(id);

            if (gastoToBeUpdated == null)
            {
                return NotFound();
            }

            var gasto = _mapper.Map<SaveGastoResource, Gasto>(saveGastoResource);

            await _gastoService.UpdateGasto(gastoToBeUpdated, gasto);

            var updatedGasto = await _gastoService.GetGastoById(id);

            var updateGastoResource = _mapper.Map<Gasto, GastoResource>(updatedGasto);

            return Ok(updateGastoResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(Guid id)
        {
            if (id == null)
                return BadRequest();

            var gasto = await _gastoService.GetGastoById(id);

            if (gasto == null)
                return NotFound();

            await _gastoService.DeleteGasto(gasto);

            return NoContent();
        }
    }
}
