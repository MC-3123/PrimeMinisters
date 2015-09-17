using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrimeMinisters.Models
{
    public class PrimeMinister
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int Year { get; set; }

        [ForeignKey("PoliticalParty")]
        public int PoliticalPartyId { get; set; }
        public PoliticalParty PoliticalParty { get; set; }




    }

    public class PoliticalParty
    {
        public int id { get; set; }
        public String PartyName { get; set; }


    }
}