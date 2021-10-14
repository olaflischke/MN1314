using HistorischeSortenDal;
using NUnit.Framework;
using System;
using System.Linq;
namespace HistorischeSortenTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsArchivInitialising()
        {
            Archiv archiv = new Archiv(@"C:\tmp\Grob\Repo\Daten\eurofxref-hist-90d.xml");  // new Archiv("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");

            Console.WriteLine(archiv.Handeltage.First().Datum);

            Assert.AreEqual(CountDays(), archiv.Handeltage.Count);
        }

        private int CountDays()
        {
            return 64;
        }
    }
}