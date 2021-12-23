using AutoMapper;
using TimeKeeping.Models;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TimeOffRequestModel, TimeOffRequest>();
        }
    }
}
