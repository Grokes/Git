using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    [PrimaryKey(nameof(Id))]
    public class GrowthOfShares
    {
        public int Id { get; set; }
        public double Percent { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
