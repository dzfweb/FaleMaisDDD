using AutoMapper;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaleMaisDDD.MVC.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AdministradorViewModel, Administrador>();
            Mapper.CreateMap<DDDViewModel, DDD>();
            Mapper.CreateMap<PlanoViewModel, Plano>();
            Mapper.CreateMap<PrecoViewModel, Preco>();
        }
    }
}
