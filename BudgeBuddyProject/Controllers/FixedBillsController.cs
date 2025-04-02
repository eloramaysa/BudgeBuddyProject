using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgeBuddyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FixedBillsController(IFixedBillService fixedBillService, IFixedBillQuery fixedBillQuery) 
    : ControllerBase
    {
        private readonly IFixedBillService _fixedBillService = fixedBillService;
        private readonly IFixedBillQuery _fixedBillQuery = fixedBillQuery;

        // GET: api/fixedbills/{id}
        [HttpGet("{id}")]
        public IActionResult GetFixedBillById(Guid id)
        {
            var fixedBill = _fixedBillQuery.GetFixedBillById(id);

            if (fixedBill.Id == Guid.Empty)
                return NotFound("Fixed bill not found.");

            return Ok(fixedBill);
        }

        // GET: api/Fixedbills/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetFixedBillsByUserId(Guid userId)
        {
            var fixedBills = _fixedBillQuery.GetFixedBillByUserId(userId);
            return Ok(fixedBills);
        }

        // POST: api/fixedbills
        [HttpPost]
        public IActionResult CreateFixedBill([FromBody] FixedBillDto fixedBillDto)
        {
            if (fixedBillDto == null)
                return BadRequest("Fixed bill data is null.");

            try
            {
                _fixedBillService.CreateFixedBill(fixedBillDto);
                return Ok(fixedBillDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/fixedbills/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateFixedBill(Guid id, [FromBody] FixedBillDto fixedBillDto)
        {
            if (fixedBillDto == null || id != fixedBillDto.Id)
                return BadRequest("Fixed bill ID mismatch or fixed bill data is null.");

            try
            {
                _fixedBillService.UpdateFixedBill(fixedBillDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/fixedbills/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFixedBill(Guid id)
        {
            try
            {
                _fixedBillService.DeleteFixedBill(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
