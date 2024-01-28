using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    internal class DataBase
    {
        public List<Investor> Investors { get; set; }
        public List<Company> Companies { get; set; }
        public List<GrowthOfShares> GrowthOfShares { get; set; }
    }
}
