using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgeBuddyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionalDescriptionsController(ITransactionalDescriptionService transactionalDescriptionService, ITransactionalDescriptionQuery transactionalDescriptionQuery)
    : ControllerBase
    {
        private readonly ITransactionalDescriptionService _transactionalDescriptionService = transactionalDescriptionService;
        private readonly ITransactionalDescriptionQuery _transactionalDescriptionQuery = transactionalDescriptionQuery;

        [HttpGet("{id}")]
        public IActionResult GetTransactionalDescriptionById(Guid id)
        {
            var transactionalDescription = _transactionalDescriptionQuery.GetTransactionalDescriptionById(id);

            if (transactionalDescription.Id == Guid.Empty)
                return NotFound("Transactional description not found.");

            return Ok(transactionalDescription);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetTransactionalDescriptionsByUserId(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            var transactionalDescriptions = _transactionalDescriptionQuery.GetTransactionalDescriptionsByUserId(userId, pageNumber, pageSize);
            return Ok(transactionalDescriptions.Items);
        }

        [HttpPost]
        public IActionResult CreateTransactionalDescription([FromBody] TransactionalDescriptionDto transactionalDescriptionDto)
        {
            if (transactionalDescriptionDto == null)
            {
                return BadRequest("Transactional description data is null.");
            }

            try
            {
                _transactionalDescriptionService.CreateTransactionalDescription(transactionalDescriptionDto);
                return Ok(transactionalDescriptionDto);
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

        [HttpPut("{id}")]
        public IActionResult UpdateTransactionalDescription(Guid id, [FromBody] TransactionalDescriptionDto transactionalDescriptionDto)
        {
            if (transactionalDescriptionDto == null || id != transactionalDescriptionDto.Id)
            {
                return BadRequest("Transactional description ID mismatch or transactional description data is null.");
            }

            try
            {
                _transactionalDescriptionService.UpdateTransactionalDescription(transactionalDescriptionDto);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteTransactionalDescription(Guid id)
        {
            try
            {
                _transactionalDescriptionService.DeleteTransactionalDescription(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
