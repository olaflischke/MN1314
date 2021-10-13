using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public Huhn()
        {
            this.Gewicht = 1000;
            this.Id = Guid.NewGuid();
        }

        public Huhn(string name) : this()
        {
            this.Name = name;
        }

        public Huhn(int gewicht) : this("Neues Huhn")
        {
            this.Gewicht = gewicht;
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);

                //this.Gewicht = this.Gewicht - ei.Gewicht;
                this.Gewicht -= ei.Gewicht;
            }

        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }

    }
}
