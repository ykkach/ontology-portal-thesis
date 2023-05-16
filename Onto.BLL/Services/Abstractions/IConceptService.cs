using Onto.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Abstractions
{
    public interface IConceptService
    {
        public Task AddAsync(ConceptChildren model);

        public Task<Concept> GetConceptByUriAsync(string uri);
    }
}
