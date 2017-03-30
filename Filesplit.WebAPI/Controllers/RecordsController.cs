using System.Collections.Generic;
using System.Linq;
using System.Net;
using Filesplit.Services;
using Filesplit.WebAPI.OutputModels;
using Microsoft.AspNetCore.Mvc;

namespace Filesplit.WebAPI.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private const string INVALID_DATA = "Invalid input data provided";
        
        private IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        
        [HttpGet("name")]
        public IEnumerable<RecordOutputModel> SortedByName()
        {
            return ListAndMap(OrderBy.LastName);
        }

        [HttpGet("birthdate")]
        public IEnumerable<RecordOutputModel> SortedByBirthDate()
        {
            return ListAndMap(OrderBy.BirthDate);
        }

        [HttpGet("gender")]
        public IEnumerable<RecordOutputModel> SortedByGender()
        {
            return ListAndMap(OrderBy.Gender);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            var result = this._recordService.Add(value);

            if (!result)
            {
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var bytes = System.Text.Encoding.UTF8.GetBytes(INVALID_DATA);
                this.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
            }
        }

        private IEnumerable<RecordOutputModel> ListAndMap(OrderBy order)
        {
            return this._recordService.List(order)
                .Select(r => new RecordOutputModel{
                    LastName = r.LastName,
                    FirstName = r.FirstName,
                    Gender = r.Gender,
                    Color = r.FavoriteColor,
                    DateOfBirth = r.DateOfBirthFormmated
                });
        }
    }
}
