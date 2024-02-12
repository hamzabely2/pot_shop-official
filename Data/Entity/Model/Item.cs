using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public partial class Item
    {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
            public float? Price { get; set; }
            public int? Stock { get; set; }
            public string? Description { get; set; }
            public DateTime? CreatedDate { get; set; } // Déclarée comme nullable
            public DateTime? UpdateDate { get; set; }  // Déclarée comme nullable
            public int CategoryId { get; set; } // Déclarée comme non-nullable
            public int ColorId { get; set; }    // Déclarée comme non-nullable
            public int MaterialId { get; set; } // Déclarée comme non-nullable
            public virtual Color Colors { get; set; } = null!;
            public virtual Material Materials { get; set; } = null!;
            public virtual Category Categories { get; set; } = null!;
            [NotMapped]
            public virtual List<byte[]> Images { get; set; } = new List<byte[]>();
    }
}
