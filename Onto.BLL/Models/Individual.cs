using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Models
{
    public class Individual
    {
        public string Uri { get; set; }

        public string Value { get; set; }

        public string? Annotation { get; set; }

        public string? DataType { get; set; }

        public string ConceptUri { get; set; }
        public ICollection<Property> DomainProperties { get; set; }
        public ICollection<Property> RangeProperties { get; set; }

        public Individual()
        {
            DomainProperties = new HashSet<Property>();
            RangeProperties = new HashSet<Property>();
        }
    }
}
