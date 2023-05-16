using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Entities
{
    public class OntologyIndividual
    {

        public string Uri { get; set; }

        public string Value { get; set; }

        public string? Annotation { get; set; }

        public string? DataType { get; set; }

        public string ConceptUri { get; set; }

        public virtual ICollection<OntologyPropertyDomain> DomainProperties { get; set; }
        public virtual ICollection<OntologyPropertyRange> RangeProperties { get; set; }

        public OntologyIndividual()
        {
            DomainProperties = new HashSet<OntologyPropertyDomain>();
            RangeProperties = new HashSet<OntologyPropertyRange>();
        }
    }
}