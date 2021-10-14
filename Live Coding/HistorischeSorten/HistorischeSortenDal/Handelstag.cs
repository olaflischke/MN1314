using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace HistorischeSortenDal
{
    public class Handelstag
    {
        public Handelstag(XElement handelstagKnoten)
        {
            this.Datum = Convert.ToDateTime(handelstagKnoten.Attribute("time").Value);

            NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            this.Waehrungen = handelstagKnoten.Descendants()
                                            .Select(kn => new Waehrung()
                                                    {
                                                        Kurs = Convert.ToDouble(kn.Attribute("rate").Value, nfiEzb),
                                                        Name = kn.Attribute("currency").Value
                                                    })
                                            .ToList();

        }

        public DateTime Datum { get; set; }
        public List<Waehrung> Waehrungen { get; set; }
    }
}