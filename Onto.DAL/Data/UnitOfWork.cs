using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Onto.DAL.Repositories.Abstractions;
using Onto.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Onto.DAL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OntologyContext _context;
        private bool _disposed;

        private IConceptRepository _conceptRepository;
        private IPropertyRepository _propertyRepository;
        private IIndividualRepository _individualRepository;

        public UnitOfWork()
        {
            _context = new OntologyContext(default); 
        }

        public UnitOfWork(OntologyContext context)
        {
            _context = context;
        }

        public IConceptRepository ConceptRepository
        {
            get
            {
                if (_conceptRepository is null)
                    _conceptRepository = new ConceptRepository(_context);
                return _conceptRepository;
            }
        }

        public IPropertyRepository PropertyRepository
        {
            get
            {
                if (_propertyRepository is null)
                    _propertyRepository = new PropertyRepository(_context);
                return _propertyRepository;
            }
        }

        public IIndividualRepository IndividualRepository
        {
            get
            {
                if (_individualRepository is null)
                    _individualRepository = new IndividualRepository(_context);
                return _individualRepository;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
