using AutoMapper;
using UserManagement.Core.Models;
using UserManagement.Dtos;

namespace UserManagement.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			//CreateMap<List<User>, List<UserDto>>().ReverseMap();
		}
	}
}
