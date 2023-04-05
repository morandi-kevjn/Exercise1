using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; // ep68
using Exercise1.Dtos; // ep68
using Exercise1.Models; // ep68

// created in ep68

namespace Exercise1.App_Start
{
    public class MappingProfile : Profile
    {
        // I missing the constructor before when I had errors on the methods called into this constructor.
        public MappingProfile()
        {
            // Automapper:  Mapper.CreateMap<Models.Customer, Dtos.CustomerDto>(); solution if I don't use the librarys
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MovieDto, Movie>(); // error -> this is for Movies not Customers
            // ep80
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); // it used before test5
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore()); // test5
        }
    }
}