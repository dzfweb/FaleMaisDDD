using AutoMapper;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaleMaisDDD.MVC.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Administrador, AdministradorViewModel>();
            Mapper.CreateMap<DDD, DDDViewModel>();
            Mapper.CreateMap<Plano, PlanoViewModel>();
            Mapper.CreateMap<Preco, PrecoViewModel>();
        }

    }
}
