using AutoMapper;
using shared.Models;
using shared.Models.ViewModels;

namespace main
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Employee, EmployeeSaveViewModel>();
            CreateMap<EmployeeSaveViewModel, Employee>();

            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
