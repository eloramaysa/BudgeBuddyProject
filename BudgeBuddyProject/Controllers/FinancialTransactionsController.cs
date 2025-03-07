using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgeBuddyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialTransactionsController(IFinancialTransactionsService financialTransactionsService, IFinancialTransactionalQuery financialTransactionalQuery) 
    : ControllerBase
    {
        private readonly IFinancialTransactionsService _financialTransactionsService = financialTransactionsService;
        private readonly IFinancialTransactionalQuery _financialTransactionalQuery = financialTransactionalQuery;

        // GET: api/financialtransactions/{id}
        [HttpGet("{id}")]
        public IActionResult GetFinancialTransactionById(Guid id)
        {
            var financialTransaction = _financialTransactionalQuery.GetFinancialTransactionsById(id);

            if (financialTransaction.Id == Guid.Empty)
                return NotFound("Financial transaction not found.");

            return Ok(financialTransaction);
        }

        // GET: api/financialtransactions/filter
        [HttpGet("filter")]
        public IActionResult GetFinancialTransactionsByFilter([FromQuery] FinancialTransactionsFilterDto filterDto, int pageNumber = 1, int pageSize = 10)
        {
            var financialTransactions = _financialTransactionalQuery.GetFinancialTransactionsByFilter(filterDto, pageNumber, pageSize);
            return Ok(financialTransactions);
        }

        // POST: api/FinancialTransactions
        [HttpPost]
        public IActionResult CreateFinancialTransaction([FromBody] FinancialTransactionsDto financialTransactionsDto)
        {
            if (financialTransactionsDto == null)
                return BadRequest("Financial transaction data is null.");

            try
            {
                _financialTransactionsService.CreateFinancialTransaction(financialTransactionsDto);
                return Ok(financialTransactionsDto);
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

        // PUT: api/financialtransactions/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateFinancialTransaction(Guid id, [FromBody] FinancialTransactionsDto financialTransactionsDto)
        {
            if (financialTransactionsDto == null || id != financialTransactionsDto.Id)
                return BadRequest("Financial transaction ID mismatch or financial transaction data is null.");

            try
            {
                _financialTransactionsService.UpdateFinancialTransaction(financialTransactionsDto);
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

        // DELETE: api/financialtransactions/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFinancialTransaction(Guid id)
        {
            try
            {
                _financialTransactionsService.DeleteFinancialTransaction(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
