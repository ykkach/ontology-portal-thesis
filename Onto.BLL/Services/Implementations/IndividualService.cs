using AutoMapper;
using Onto.BLL.Models;
using Onto.BLL.Services.Abstractions;
using Onto.DAL.Data;
using Onto.DAL.Entities;
using Onto.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Implementations
{
    public  class IndividualService : Service, IIndividualService
    {
        public IndividualService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task AddAsync(Individual model)
        {
            if (string.IsNullOrEmpty(model.Uri) ||
                string.IsNullOrEmpty(model.Value))
            {
                throw new NullReferenceException();
            }

            var conceptEntity = _mapper.Map<Individual, OntologyIndividual>(model);
            await _unitOfWork.IndividualRepository.AddIndividualAsync(conceptEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ICollection<Individual>> GetIndividuals(string conceptUri)
        {
            if (string.IsNullOrEmpty(conceptUri))
            {
                throw new NullReferenceException();
            }

            var conceptEntity = await _unitOfWork.ConceptRepository.GetByUriAsync(conceptUri);

            return _mapper.Map <ICollection<OntologyIndividual>, ICollection<Individual>>( conceptEntity.Instances)
        }
    }
}
