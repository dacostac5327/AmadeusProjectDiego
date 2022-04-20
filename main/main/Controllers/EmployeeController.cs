using AutoMapper;
using main.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using shared.Models;
using shared.Models.ViewModels;
using shared.Services;
using System.Net;

namespace main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public readonly IMapper Mapper;
        public EmployeeController(IEmployeeServices employeeServices, IMapper mapper)
        {
            _employeeServices = employeeServices;
            Mapper = mapper;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var response = new ResponseBase<List<EmployeeViewModel>>();
            try
            {
                var employees = await _employeeServices.GetEmployees();
                var mappedUser = Mapper.Map<List<EmployeeViewModel>>(employees);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = mappedUser;
                response.Count = employees.Count;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }


        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = new ResponseBase<EmployeeViewModel>();
            try
            {
                var employees = await _employeeServices.GetEmployeeById(id);
                var mappedUser = Mapper.Map<EmployeeViewModel>(employees);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = mappedUser;
                response.Count = 1;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeSaveViewModel data)
        {
            var response = new ResponseBase<Employee>();
            try
            {
                var mappedUser = Mapper.Map<Employee>(data);
                var employees = await _employeeServices.Add(mappedUser);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = mappedUser;
                response.Count = 1;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeViewModel data)
        {
            var response = new ResponseBase<Employee>();
            try
            {
                var mappedUser = Mapper.Map<Employee>(data);
                var employees = await _employeeServices.Update(mappedUser);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = mappedUser;
                response.Count = 1;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(EmployeeViewModel data)
        {
            var response = new ResponseBase<Employee>();
            try
            {
                var mappedUser = Mapper.Map<Employee>(data);
                var employees = await _employeeServices.Delete(mappedUser);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = mappedUser;
                response.Count = 1;
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
