using AspNetWebApiProje.API.Dtos;
using AspNetWebApiProje.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProje.API.Mapping
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<Personel, PersonelDto>().ReverseMap();
           
            CreateMap<Personel, PersonelWithAdresDto>().ReverseMap();
            CreateMap<Adres, AdresDto>().ReverseMap();
            CreateMap<Personel, CreatePersonelDto>().ReverseMap();
        }
    }
}
