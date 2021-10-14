using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace HistorischeSortenDal
{
    public class Archiv
    {
        public Archiv(string url)
        {
            this.Handeltage = HoleDaten(url);
        }

        /// <summary>
        /// Liest die Daten einer GESMES-Datei und gibt eine Liste von HandelstagObjketen zurück.
        /// </summary>
        /// <param name="url">Pfad order URL der Datei.</param>
        /// <returns>Eine Liste von Handelstagen.</returns>
        private List<Handelstag> HoleDaten(string url)
        {
            List<Handelstag> handelstage = new List<Handelstag>();

            XDocument document = XDocument.Load(url);

            var q = from nd in document.Root.Descendants()
                    where nd.Name.LocalName == "Cube" && nd.Attributes().Any(at => at.Name == "time")
                    // Projektion
                    select new Handelstag(nd);
                    

            //var q2=document.Root.Descendants().Where(nd => nd.Name=="Cube")
            //                                .Select(nd => new Handelstag() {  Datum = ...})

            handelstage = q.ToList();

            //foreach (XElement item in q)
            //{
            //    Handelstag handelstag = new Handelstag()

            //    handelstage.Add(handelstag);
            //}

            return handelstage;
        }

        //private List<Handelstag> HoleDatenMitXmlReader(string url)
        //{
        //    XmlReader reader = XmlReader.Create(url);

        //    while (reader.Read())
        //    {
        //        if (reader.Name == "Cube")
        //        {
        //            if (reader.AttributeCount == 1)
        //            {
        //                Handelstag handelstag = new Handelstag()
        //                {
        //                    Datum = Convert.ToDateTime(reader.GetAttribute("time"))
        //                };
        //            }
        //            else if (reader.AttributeCount == 2)
        //            {
        //                // Waehrung erstellen
        //            }
        //        }
        //    }

        //}

        public List<Handelstag> Handeltage { get; set; }
    }
}
