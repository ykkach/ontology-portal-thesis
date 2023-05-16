using AutoMapper;
using Onto.BLL.Models;
using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Concept, OntologyConcept>()
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ConceptChildren, OntologyConcept>()
                .IncludeBase<Concept, OntologyConcept>()
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children))
                .ForMember(dest => dest.Instances, opt => opt.MapFrom(src => src.Individuals))
                .ReverseMap();

            CreateMap<OntologyIndividual, Individual>()
                .ForMember(dest => dest.DomainProperties, opt => opt.MapFrom(src => src.DomainProperties))
                .ForMember(dest => dest.RangeProperties, opt => opt.MapFrom(src => src.RangeProperties))
                .ReverseMap();
        }
    }
}
