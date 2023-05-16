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
    public class IndividualRepository : IIndividualRepository
    {
        public IndividualRepository(OntologyContext context)
        {
            _context = context;
            _entities = _context.Set<OntologyIndividual>();
        }

        protected OntologyContext _context { get; set; }
        protected DbSet<OntologyIndividual> _entities { get; set; }

        public async Task AddIndividualAsync(OntologyIndividual entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<OntologyIndividual> FindInstancesByConcept(string uri)
        {
            return _entities.Where(i => i.ConceptUri == uri);
        }
    }
}
