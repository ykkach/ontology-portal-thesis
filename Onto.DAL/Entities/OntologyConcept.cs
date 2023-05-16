using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.DAL.Entities
{
    public class OntologyConcept
    {
        public string Uri { get; set; }

        public string Annotation { get; set; }

        public string? ParentId { get; set; }
        public virtual OntologyConcept Parent { get; set; }
        public virtual ICollection<OntologyConcept> Children { get; set; }

        public virtual ICollection<OntologyIndividual> Instances { get; set; }

        public OntologyConcept()
        {
            Instances = new HashSet<OntologyIndividual>();
            Children = new HashSet<OntologyConcept>();
        }   
    }
}
