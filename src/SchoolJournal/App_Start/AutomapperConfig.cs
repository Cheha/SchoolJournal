using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SchoolJournal.Domain;
using SchoolJournal.Models;
using SchoolJournal.Services;

namespace SchoolJournal
{
    public class AutoMapperConfig
    {
        private static IHashidService _hashidService = new HashidService();

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {

                cfg.CreateMap<SchoolClass, SchoolClassViewModel>()
                    .ForMember(dest => dest.SchoolClassName, opt => opt.MapFrom(source => source.Name));

                cfg.CreateMap<Mark, MarkViewModel>()
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => _hashidService.Encode(src.StudentId)))
                    .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => _hashidService.Encode(src.SubjectId)));

                cfg.CreateMap<MarkPostViewModel, Mark>()
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => _hashidService.Decode(src.StudentId)))
                    .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => _hashidService.Decode(src.SubjectId)));
            });
        }
    }
}