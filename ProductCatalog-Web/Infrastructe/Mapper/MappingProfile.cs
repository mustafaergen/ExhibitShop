using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductCatolog_Core.DTOs;
using ProductCatolog_Core.Models;
using ProductCatolog_Core.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }

}
