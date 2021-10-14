using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    /// <summary>
    /// Stellt Eigenschaften und Methoden zum Eilegen bereit.
    /// </summary>
    public interface IEileger
    {
        /// <summary>
        /// Gewicht des Tiers
        /// </summary>
        double Gewicht { get; set; }
        /// <summary>
        /// Die Eier, die das Tier bereits gelegt hat.
        /// </summary>
        List<Ei> Eier { get; set; }

        /// <summary>
        /// Das Tier legt ein Ei.
        /// </summary>
        void EiLegen();
    }
}