using System.Collections.Generic;
using Filesplit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filesplit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        // usually this would use DI
        private IRecordService _recordService = new RecordService();
        
        // GET api/values
        [HttpGet("name")]
        public IEnumerable<Record> SortedByName()
        {
            return _recordService.List(OrderBy.LastName);
        }

        [HttpGet("birthdate")]
        public IEnumerable<Record> SortedByBirthDate()
        {
            return _recordService.List(OrderBy.BirthDate);
        }

        [HttpGet("gender")]
        public IEnumerable<Record> SortedByGender()
        {
            return _recordService.List(OrderBy.Gender);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            this._recordService.Add(value);
        }
    }
}
