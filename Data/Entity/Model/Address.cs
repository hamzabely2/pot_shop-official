using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int? Code { get; set; } = 0!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
