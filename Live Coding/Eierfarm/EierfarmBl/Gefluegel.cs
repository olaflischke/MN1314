using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEileger
    {
        public event EventHandler EigenschaftGeaendert;

        private void OnEigenschaftGeaendert()
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new EventArgs());
            }
        }

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnEigenschaftGeaendert();
            }
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnEigenschaftGeaendert();
            }
        }

        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void Fressen();
        public abstract void EiLegen();

        public void Gackern()
        {

        }
    }
}
