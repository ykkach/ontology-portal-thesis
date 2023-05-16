using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Models
{
    public class ConceptChildren : Concept
    {
        public ICollection<Concept> Children { get; set; }

        public ICollection<Individual> Individuals { get; set; }

        public ConceptChildren(string uri, string parentId) : base(uri, parentId)
        {
            Children = new List<Concept>();
            Individuals = new List<Individual>();
        }
    }
}
