using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruitment_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledCandidatesController : ControllerBase
    {
        private readonly ICandidateRepo _repo;

        public ScheduledCandidatesController(ICandidateRepo candidate)
        {
            this._repo = candidate;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCandidates()
        {
            var result = await _repo.GetAllCandidates();
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCandidateDetails(int ID)
        {
            var result = await _repo.GetCandidateDetails(ID);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateCandidate([FromBody]CreateCandidate candidate)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _repo.CreateCandidate(candidate);
            }
            if (result == true)
                return Ok();
            else
                return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCandidate([FromBody]CreateCandidate candidate)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = await _repo.UpdateCandidate(candidate);
            }
            if (result == true)
                return Accepted();
            else
                return NoContent();
        }

    }
}