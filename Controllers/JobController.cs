using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreCandidates.Domain.Entities;
using StoreCandidates.Infra;
using StoreCandidates.Models;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StoreCandidates.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _repository;
        private readonly ILogger<JobController> _logger;
        private readonly IMapper _mapper;

        public JobController(IJobRepository repository, ILogger<JobController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// insert a job.
        /// </summary>
        /// <param name="job"></param>
        /// <returns>A newly created job</returns>
        /// <response code="201">Returns the newly job item</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(JobResult), StatusCodes.Status201Created)]
        public async Task<ActionResult<JobResult>> Insert(JobRequest job)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Request");
                }
                var jobMapped = _mapper.Map<Job>(job);

                await _repository.InsertAsync(jobMapped);

                return Created("", jobMapped);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return BadRequest("Invalid Request");
            }
        }

        /// <summary>
        /// insert a job.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A job</returns>
        /// <response code="200">Returns the job</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        /// 
        [ProducesResponseType(typeof(JobResult), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<JobResult>> Get(int id)
        {
            try
            {
                var job = await _repository.GetByIdAsync(id);
                if (job != null)
                {
                    var jobMapped = _mapper.Map<JobResult>(job);
                    return Ok(jobMapped);
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
        /// return all a jobs.
        /// </summary>
        /// <returns>A jobs</returns>
        /// <response code="200">Returns all jobs</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<JobResult>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<JobRequest>> GetAll()
        {
            try
            {
                var job = await _repository.GetAll();
                if (job != null)
                {
                    var candidateMapped = _mapper.Map<IEnumerable<JobResult>>(job);
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
        /// return update a job.
        /// </summary>
        /// <param name="job"></param>
        /// <returns>A job</returns>
        /// <response code="200">Returns a job</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<JobResult>), StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<JobRequest>> Update([FromBody] JobRequest job)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Request");

                var jobdb = await _repository.GetByIdAsync(job.Id);
                if (jobdb != null)
                {

                    var jobMapped = _mapper.Map(job, jobdb);
                    await _repository.UpdateAsync(jobMapped);
                    return Ok(job);
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
        /// return update a job.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A job</returns>
        /// <response code="200">delete a job</response>
        /// <response code="400">If the item is invalid</response>    
        /// <response code="401">If is not authorized</response>     
        [ProducesResponseType(typeof(IEnumerable<JobResult>), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobRequest>> Delete(int id)
        {
            try
            {
                var job = await _repository.GetByIdAsync(id);
                if (job != null)
                {
                    await _repository.DeleteAsync(job);
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

