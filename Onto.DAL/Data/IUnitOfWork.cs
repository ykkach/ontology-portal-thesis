using Onto.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Data
{
    public  interface IUnitOfWork
    {
        IConceptRepository ConceptRepository { get; }
        IIndividualRepository IndividualRepository { get; }
        IPropertyRepository PropertyRepository { get; }

        int Save();
        Task<int> SaveAsync();

    }
}
