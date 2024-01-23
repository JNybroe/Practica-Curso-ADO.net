using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discos
{
    public class Estilo
    {
        public int Id {  get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
}
