using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Gans : Gefluegel
    {
        public Gans()
        {
            this.Name = "Neue Gans";
            this.Gewicht = 2000;
            this.Id = Guid.NewGuid();
        }

        public int Steuerkurs { get; set; }

        public override void EiLegen()
        {
            if (Gewicht>2000)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht<5000)
            {
                this.Gewicht += 250;
            }
        }
    }
}
