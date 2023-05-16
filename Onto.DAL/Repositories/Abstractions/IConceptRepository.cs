using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Repositories.Abstractions
{
    public interface IConceptRepository
    {
        public Task AddConceptAsync(OntologyConcept entity);
        public IQueryable<OntologyConcept> FindChildrenByParent(string uri);
        public Task<OntologyConcept> GetByIdAsync(string uri);
    }
}
