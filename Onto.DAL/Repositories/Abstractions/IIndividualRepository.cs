using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Repositories.Abstractions
{
    public interface IIndividualRepository
    {
        public Task AddIndividualAsync(OntologyIndividual entity);
        public IQueryable<OntologyIndividual> FindInstancesByConcept(string uri);
    }
}
