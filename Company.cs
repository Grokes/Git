using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    [PrimaryKey(nameof(Id))]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Investment { get; set; }
    }
}
