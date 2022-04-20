using AutoMapper;
using main.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using shared.Models;
using shared.Services;
using System.Net;

namespace main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EPSController : ControllerBase
    {
        private readonly IEPSServices _EPSServices;
        public readonly IMapper Mapper;
        public EPSController(IEPSServices EPSServices, IMapper mapper)
        {
            _EPSServices = EPSServices;
            Mapper = mapper;
        }

        [HttpGet("GetEPSs")]
        public async Task<IActionResult> GetEPSs()
        {
            var response = new ResponseBase<List<EPS>>();
            try
            {
                var EPSs = await _EPSServices.GetEPSs();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = EPSs;
                response.Count = EPSs.Count;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }
    }
}
