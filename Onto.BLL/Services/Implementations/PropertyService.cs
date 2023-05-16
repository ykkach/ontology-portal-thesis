using AutoMapper;
using Onto.BLL.Services.Abstractions;
using Onto.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Implementations
{
    public class PropertyService : Service, IPropertyService
    {
        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public string GetPropertiesByDomain(string domainUri)
        {
            throw new NotImplementedException();
        }

        public string GetPropertiesByRange(string domainUri)
        {
            throw new NotImplementedException();
        }
    }
}
