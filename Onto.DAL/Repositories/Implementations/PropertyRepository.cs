using Microsoft.EntityFrameworkCore;
using Onto.DAL.Data;
using Onto.DAL.Entities;
using Onto.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Repositories.Implementations
{
    public class PropertyRepository : IPropertyRepository
    {

        public PropertyRepository(OntologyContext context)
        {
            _context = context;
            _entities = _context.Set<OntologyProperty>();
        }

        protected OntologyContext _context { get; set; }
        protected DbSet<OntologyProperty> _entities { get; set; }

        public async Task AddPropertyAsync(OntologyProperty entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OntologyProperty> FindPropertiesByDomain(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<OntologyProperty> GetByUriAsync(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
