using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreCandidates.Domain.Entities;
using StoreCandidates.Infra;
using StoreCandidates.Model;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StoreCandidates.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CanditateController : ControllerBase
    {
        private readonly ICandidateRepository _repository;
        private readonly ILogger<CanditateController> _logger;
        private readonly IMapper _mapper;
        public CanditateController(ILogger<CanditateController> logger, ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// insert a Candidate.
        /// </summary>
        /// <param name="canditate"></param>
        /// <returns>A newly created canditate</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(CandidateResult), StatusCodes.Status201Created)]
        public async Task<ActionResult<CandidateResult>> Insert(CandidateRequest canditate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Request");
                }
                var candidateMapped = _mapper.Map<Candidate>(canditate);

                await _repository.InsertAsync(candidateMapped);

                return Created("", canditate);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }
        }

        /// <summary>
        /// insert a Candidate.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A canditate</returns>
        /// <response code="200">Returns the canditate</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        /// 
        [ProducesResponseType(typeof(CandidateResult), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateResult>> Get(int id)
        {
            try
            {
                var candidate = await _repository.GetByIdAsync(id);
                if (candidate != null)
                {
                    var candidateMapped = _mapper.Map<CandidateResult>(candidate);
                    return Ok(candidateMapped);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }
        }

        /// <summary>
        /// return all a candidates.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A canditate</returns>
        /// <response code="200">Returns all canditates</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<CandidateResult>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<CandidateRequest>> GetAll()
        {
            try
            {
                var candidate = await _repository.GetAll();
                if (candidate != null)
                {
                    var candidateMapped = _mapper.Map<IEnumerable<CandidateResult>>(candidate);
                    return Ok(candidateMapped);
                }

                return NotFound();
            }
            catch (Exception e)
            {

                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }
        }

        /// <summary>
        /// return update a candidate.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns>A canditate</returns>
        /// <response code="200">Returns a canditates</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<CandidateResult>), StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<CandidateRequest>> Update([FromBody] CandidateRequest candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Request");

                var candidatedb = await _repository.GetByIdAsync(candidate.Id);
                if (candidatedb != null)
                {

                    var candidateMapped = _mapper.Map(candidate, candidatedb);
                    await _repository.UpdateAsync(candidateMapped);
                    return Ok(candidate);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// return update a candidate.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns>A canditate</returns>
        /// <response code="200">delete a canditate</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<CandidateResult>), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateRequest>> Delete(int id)
        {
            try
            {
                var candidate = await _repository.GetByIdAsync(id);
                if (candidate != null)
                {
                    await _repository.DeleteAsync(candidate);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }

        }

    }


}

