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
    public class ARLController : ControllerBase
    {
        private readonly IARLServices _ARLServices;
        public readonly IMapper Mapper;
        public ARLController(IARLServices ARLServices, IMapper mapper)
        {
            _ARLServices = ARLServices;
            Mapper = mapper;
        }

        [HttpGet("GetARLs")]
        public async Task<IActionResult> GetARLs()
        {
            var response = new ResponseBase<List<ARL>>();
            try
            {
                var ARLs = await _ARLServices.GetARLs();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = ARLs;
                response.Count = ARLs.Count;
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
