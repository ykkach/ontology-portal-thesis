using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Repositories.Abstractions
{
    public interface IPropertyRepository
    {
        public Task AddPropertyAsync(OntologyProperty entity);
        public IQueryable<OntologyProperty> FindPropertiesByDomain(string uri);
        public Task<OntologyProperty> GetByUriAsync(string uri);
    }
}
