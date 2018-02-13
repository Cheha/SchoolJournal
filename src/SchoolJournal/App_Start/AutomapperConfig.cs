using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
//using SchoolJounal.Model;
using SchoolJournal.Domain;
using SchoolJournal.Models;

namespace SchoolJournal
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<SchoolClass, SchoolClassViewModel>()
                    .ForMember(dest => dest.SchoolClassName, opt => opt.MapFrom(source => source.Name));
            });
        }
    }
}