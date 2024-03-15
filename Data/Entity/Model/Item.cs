using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public partial class Item
    {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }
            public float Height { get; set; }
            public float Width { get; set; }
            public float Weight { get; set; }
            public string Description { get; set; }
            public DateTime CreatedDate { get; set; } 
            public DateTime UpdateDate { get; set; }  
            public int CategoryId { get; set; } 
            public int MaterialId { get; set; }
            public virtual List<ColorItem> ColorsItems { get; set; }
            public virtual Material Materials { get; set; } = null!;
            public virtual Category Categories { get; set; } = null!;
            public Item()
            {
                Images = new List<Image>();
            }
             [NotMapped]
            public virtual List<Image> Images { get; set; }
    }
}
