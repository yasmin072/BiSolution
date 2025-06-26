using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIApplication.Core.models.territory
{
    public class TotalVenteByTerritoryGroupDto
    {
        public string TerritoryGroup { get; set; } // Nom du groupe de territoire (e.g., "North America", "Europe")

        // Propriété pour le total des ventes (basé sur [Measures].[Line Total - Sum])
        public decimal LineTotalSum { get; set; }
    }
}
