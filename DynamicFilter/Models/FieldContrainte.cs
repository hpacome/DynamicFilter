using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicFilter.Models
{
    public class FieldContrainte
    {
        public string FieldName { get; set; }

        public string Operator { get; set; }

        public List<Contrainte> Contraintes { get; set; }
    }
}
