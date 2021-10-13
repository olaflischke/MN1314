using System;

namespace EierfarmBl
{
    public class Ei
    {
        public Ei(Gefluegel mutter)
        {
            this.Legedatum = DateTime.Today;
                      
            Random random = new Random();
            //VB.NET:
            //Dim random as Random = new Random

            this.Gewicht = random.Next(45, 81);
            this.Farbe = (EiFarbe)random.Next(Enum.GetNames(typeof(EiFarbe)).Length); // DirectCast - Vorsicht, Exceptions!

            this.Mutter = mutter;
        }

        // Backing Field
        private double _gewicht;

        // Fulllqualified Property mit Backing Field
        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                _gewicht = value;
            }
        }

        // Auto-Property
        // Property mit automatisch generiertem Backing Field
        public DateTime Legedatum { get; private set; }

        public EiFarbe Farbe { get; set; }
        public Gefluegel Mutter { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}
