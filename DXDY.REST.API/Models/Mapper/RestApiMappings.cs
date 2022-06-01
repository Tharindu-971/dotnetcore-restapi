using AutoMapper;
using DXDY.REST.API.Models.Dtos;

namespace DXDY.REST.API.Models.Mapper
{
    public class RestApiMappings : Profile
    {
        public RestApiMappings()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
