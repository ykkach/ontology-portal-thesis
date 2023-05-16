using Microsoft.EntityFrameworkCore;
using Onto.DAL.Data;
using Onto.DAL.Entities;
using Onto.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onto.DAL.Repositories.Implementations
{
    public class ConceptRepository : IConceptRepository
    {
        public ConceptRepository(OntologyContext context) 
        {
            _context = context;
            _entities = _context.Set<OntologyConcept>(); 
        }

        protected OntologyContext _context { get; set; }
        protected DbSet<OntologyConcept> _entities { get; set; }

        public async Task AddConceptAsync(OntologyConcept entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<OntologyConcept> FindChildrenByParent(string uri)
        {
            return _entities.Where(c => c.Parent.Uri == uri);
        }

        public async Task<OntologyConcept> GetByUriAsync(string uri)
        {
            return await _entities.FirstOrDefaultAsync(c => c.Uri == uri);
        }
    }
}
