using System.Collections.Generic;
using System.Linq;
using Filesplit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filesplit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecordsController : Controller
    {
        private IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        
        // GET api/values
        [HttpGet("name")]
        public IEnumerable<object> SortedByName()
        {
            return ListAndMap(OrderBy.LastName);
        }

        [HttpGet("birthdate")]
        public IEnumerable<object> SortedByBirthDate()
        {
            return ListAndMap(OrderBy.BirthDate);
        }

        [HttpGet("gender")]
        public IEnumerable<object> SortedByGender()
        {
            return ListAndMap(OrderBy.Gender);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            this._recordService.Add(value);
        }

        private IEnumerable<object> ListAndMap(OrderBy order)
        {
            return this._recordService.List(order)
                .Select(r => new {
                    lastName = r.LastName,
                    firstName = r.FirstName,
                    gender = r.Gender,
                    color = r.FavoriteColor,
                    dateOfBirth = r.DateOfBirthFormmated
                });
        }
    }
}
