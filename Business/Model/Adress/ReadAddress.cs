using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Adress
{
    public class ReadAddress
    {
        public string Id { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int? Code { get; set; }
    }
}
