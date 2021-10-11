using AutoMapper;
using Investeer.Models.Models;
using Investeer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
namespace Investeer.Utility
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<PropertyDetail, PropertyViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.C))
                .ForMember(dest => dest.County, opt => opt.MapFrom(src => src.SheetName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.J))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.I))
                .ForMember(dest => dest.BedCount, opt => opt.MapFrom(src => src.G))
                .ForMember(dest => dest.BathCount, opt => opt.MapFrom(src => src.H))
                .ForMember(dest => dest.ListedPrice, opt => opt.MapFrom(src => src.K))
                .ForMember(dest => dest.LoanRate, opt => opt.MapFrom(src => src.AF))
                .ForMember(dest => dest.LoanReturn, opt => opt.MapFrom(src => src.AG))
                .ForMember(dest => dest.CashRate, opt => opt.MapFrom(src => src.AJ))
                .ForMember(dest => dest.CashReturn, opt => opt.MapFrom(src => src.AK))
                .ReverseMap();
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .BeforeMap((s, d) => d.StatusId = 1)
                .BeforeMap((s, d) => d.AddedDt = DateTime.Now)
                .ReverseMap();
            CreateMap<RegisterViewModel, LoginViewModel>().ReverseMap();
        }
    }
}
