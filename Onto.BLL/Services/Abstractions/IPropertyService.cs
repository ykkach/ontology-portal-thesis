using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Abstractions
{
    public interface IPropertyService
    {
        public string GetPropertiesByDomain(string domainUri);
    }
}
