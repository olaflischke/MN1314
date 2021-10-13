using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel
    {
        public double Gewicht { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void Fressen();
        public abstract void EiLegen();

        public void Gackern()
        {

        }
    }
}
