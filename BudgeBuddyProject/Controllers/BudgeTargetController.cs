﻿using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgeBuddyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgeTargetController(IBudgeTargetService budgeTargetService, IBudgeTargetQuery budgeTargetQuery)
    : ControllerBase
    {
        private readonly IBudgeTargetService _budgeTargetService = budgeTargetService;
        private readonly IBudgeTargetQuery _budgeTargetQuery = budgeTargetQuery;

        [HttpGet("{id}")]
        public IActionResult GetBudgeTargetById(Guid id)
        {
            var budgeTarget = _budgeTargetQuery.GetBudgeTargetById(id);

            if (budgeTarget.Id == Guid.Empty)
                return NotFound("BudgeTarget not found.");

            return Ok(budgeTarget);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetBudgeTargetsByUserId(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            var budgeTargets = _budgeTargetQuery.GetBudgeTargetsByUserId(userId, pageNumber, pageSize);
            return Ok(budgeTargets);
        }

        [HttpPost]
        public IActionResult CreateBudgeTarget([FromBody] BudgeTargetDto budgeTargetDto)
        {
            if (budgeTargetDto == null)
                return BadRequest("BudgeTarget data is null.");

            try
            {
                _budgeTargetService.CreateBudgeTarget(budgeTargetDto);
                return Ok();
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
        public IActionResult UpdateBudgeTarget(Guid id, [FromBody] BudgeTargetDto budgeTargetDto)
        {
            if (budgeTargetDto == null || id != budgeTargetDto.Id)
                return BadRequest("BudgeTarget ID mismatch or budgeTarget data is null.");

            try
            {
                _budgeTargetService.UpdateBudgeTarget(budgeTargetDto);
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
        public IActionResult DeleteBudgeTarget(Guid id)
        {
            try
            {
                _budgeTargetService.DeleteBudgeTarget(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
