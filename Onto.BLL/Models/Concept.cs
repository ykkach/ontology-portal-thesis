using Onto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Models
{
    public class Concept
    {
        public string Uri { get; set; }

        public string? ParentId { get; set; }

        public Concept(string uri, string parentId)
        {
            Uri = uri;
            ParentId = parentId;
        }
    }
}
