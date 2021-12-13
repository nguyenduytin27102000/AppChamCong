using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeping.Models;
using TimeKeeping.ViewModels;

namespace TimeKeeping.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TimeOffRequestModel, YeuCauNghiPhep>();
        }
    }
}
