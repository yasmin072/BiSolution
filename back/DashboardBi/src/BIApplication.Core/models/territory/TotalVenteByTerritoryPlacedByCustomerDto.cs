using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIApplication.Core.models.territory
{
  /*  public class TotalVenteByTerritoryPlacedByCustomerDto
    {
        public string TerritoryName { get; set; }

        // Propriété pour le total des ventes (basé sur [Measures].[Line Total - Sum])
       // public decimal LineTotalSum { get; set; }

        // Propriété pour indiquer si la commande a été placée par un client (1 ou 0)
        public int PlacedByCustomer { get; set; }
        public Dictionary<string, decimal> LineTotalSumsByYear { get; set; }
        public TotalVenteByTerritoryPlacedByCustomerDto()
        {
            LineTotalSumsByYear = new Dictionary<string, decimal>();
            PlacedByCustomer = 1;
        }

        // Constructeur par défaut pour initialiser PlacedByCustomer à 1
        /*public TotalVenteByTerritoryPlacedByCustomerDto()
        {
            PlacedByCustomer = 1; // Toutes les lignes respectent la condition WHERE
        }
        
       // public int Year { get; set; } 
        
    } */
  public class TotalVenteByTerritoryPlacedByCustomerDto
  {
      public string TerritoryName { get; set; }

      // Total global par territoire
      public decimal totalLine { get; set; }

      public int PlacedByCustomer => 1; // Toujours à 1 car filtré dans MDX
  }

}
