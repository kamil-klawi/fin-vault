using AutoMapper;
using IdentityService.Application.Commands.CreateUser;
using IdentityService.Domain.Entities;
using IdentityService.Domain.ValueObjects;
using SharedLibrary.Common.ValueObjects;

namespace IdentityService.Application.Dtos
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<CreateUserCommand, User>()
                .ForMember(user => user.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(user => user.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(user => user.PersonalData, opt => opt.MapFrom(
                    src => new PersonalData(
                        src.FirstName,
                        src.LastName,
                        new Pesel(src.Pesel),
                        src.Gender,
                        src.BirthDate,
                        src.PlaceOfBirth,
                        src.Nationality,
                        new PhoneNumber(src.PhoneNumber),
                        new Address(src.Address.Street, src.Address.City, src.Address.PostalCode, src.Address.Country))));
        }
    }
}
