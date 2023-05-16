using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Models
{
    public class Property
    {
        public string Uri { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }
        public ICollection<Concept> DomainConcepts { get; set; }
        public ICollection<Concept> RangeConcepts { get; set; }

        public Property() 
        {
            DomainConcepts = new List<Concept>();
            RangeConcepts = new List<Concept>();
        }
    }
}
