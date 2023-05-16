using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Entities
{
    public class OntologyProperty
    {
        public string Uri { get; set; }
        public string Annotation { get; set; }
        public virtual ICollection<OntologyPropertyDomain> DomainConcepts { get; set; }
        public virtual ICollection<OntologyPropertyRange> RangeConcepts { get; set; }

        public OntologyProperty()
        {
            RangeConcepts = new HashSet<OntologyPropertyRange>();
            DomainConcepts = new HashSet<OntologyPropertyDomain>();
        }
    }
}
