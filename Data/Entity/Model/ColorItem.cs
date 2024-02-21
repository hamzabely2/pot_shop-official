using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public partial class ColorItem
    {
        [Key]
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ItemId { get; set; }
        public virtual Color? Color { get; set; } = null!;
        public virtual Item? Item { get; set; } = null!;

    }
}
