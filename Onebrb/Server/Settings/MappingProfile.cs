using AutoMapper;
using Onebrb.Shared.ViewModels.Message;
using Onebrb.Shared.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Server.Settings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Message, CreateMessageViewModel>()
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.Recipient, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Models.ApplicationUser, UserViewModel>()
                .ReverseMap();
        }
    }
}
