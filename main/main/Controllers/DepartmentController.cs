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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        public readonly IMapper Mapper;
        public DepartmentController(IDepartmentServices departmentServices, IMapper mapper)
        {
            _departmentServices = departmentServices;
            Mapper = mapper;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = new ResponseBase<List<Department>>();
            try
            {
                var departments = await _departmentServices.GetDepartments();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = departments;
                response.Count = departments.Count;
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
