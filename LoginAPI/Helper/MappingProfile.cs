using AutoMapper;
using LoginAPI.Dto;
using LoginAPI.Model;

namespace LoginAPI.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
