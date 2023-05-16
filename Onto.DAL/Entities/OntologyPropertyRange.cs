using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Onto.DAL.Entities
{
    public class OntologyPropertyRange
    {
        public string ConceptRangeUri { get; set; }
        public string PropertyUri { get; set; }

        public virtual OntologyIndividual Concept { get; set; }
        public virtual OntologyProperty Property { get; set; }
    }
}
