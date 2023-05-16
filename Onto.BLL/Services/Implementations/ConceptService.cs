using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onto.BLL.Models;
using Onto.BLL.Services.Abstractions;
using Onto.DAL.Data;
using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Implementations
{
    public class ConceptService : Service, IConceptService
    {
        public ConceptService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task AddAsync(ConceptChildren model)
        {
            if (string.IsNullOrEmpty(model.Uri) ||
                string.IsNullOrEmpty(model.ParentId)){
                throw new NullReferenceException();
            }

            var conceptEntity = _mapper.Map<ConceptChildren, OntologyConcept>(model);
            await _unitOfWork.ConceptRepository.AddConceptAsync(conceptEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Concept> GetConceptByUriAsync(string uri)
        {
            OntologyConcept ontologyConcept = await _unitOfWork.ConceptRepository.GetByUriAsync(uri);

            if (ontologyConcept == null)
                return null;

            Concept concept = _mapper.Map<OntologyConcept, Concept>(ontologyConcept);

            if (concept is ConceptChildren conceptWithChildren)
            {
                var children = _unitOfWork.ConceptRepository.FindChildrenByParent(uri);
                var instances = _unitOfWork.IndividualRepository.FindInstancesByConcept(uri);

                conceptWithChildren.Children = await children.Select(c => _mapper.Map<OntologyConcept, Concept>(c)).ToListAsync();
                conceptWithChildren.Individuals = await instances.Select(i => _mapper.Map<OntologyIndividual, Individual>(i)).ToListAsync();
            }

            return concept;
        }
    }
}
