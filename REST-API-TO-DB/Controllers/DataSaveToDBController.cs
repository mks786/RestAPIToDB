using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST_API_TO_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_TO_DB.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataSaveToDBController : ControllerBase
    {
        private readonly RESTAPI2DBContext _context;
        private readonly ILogger<DataSaveToDBController> _logger;

        public DataSaveToDBController(ILogger<DataSaveToDBController> logger, RESTAPI2DBContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<RESTAPI2DB>> Post([FromBody] RESTAPI2DB ScheduleResult)
        {
            try
            {
                _context.Schedules.AddRange(ScheduleResult.ScheduleResult.Schedules);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Data saved successfully!", Total_records = _context.Schedules.Count() }); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
