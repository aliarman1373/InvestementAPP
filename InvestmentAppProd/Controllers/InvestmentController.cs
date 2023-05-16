using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestmentAppProd.Core.Interfaces;
using InvestmentAppProd.Core.Models;
using InvestmentAppProd.Models;
using AutoMapper;

namespace InvestmentAppProd.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvestmentController : Controller
    {

        private readonly IInvestmentService _service;
        private readonly IMapper _mapper;
        public InvestmentController(IInvestmentService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetInvestments()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetInvestment([FromRoute] Guid id)
        {

            return Ok(await _service.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<ActionResult<Investment>> AddInvestment([FromBody] AddInvestmentModel model)
        {
            await _service.CreateAsync(_mapper.Map<Investment>(model));
            return CreatedAtAction("AddInvestment", model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvestment([FromRoute] Guid id, [FromBody] Investment model)
        {
            return Ok(await _service.UpdateAsync(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvestment([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();

        }
    }
}
