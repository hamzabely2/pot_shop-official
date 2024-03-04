using Entity.Model;
using Model.DetailsItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Item
{
    public class ReadItem
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float? Price { get; set; }
        public int? Stock { get; set; }
        public string Description { get; set; } = null!;
        public CategoryDto Categories { get; set; }
        public List<ColorDto> Colors { get; set; }= new List<ColorDto>();
        public ReadMaterial Materials { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public DateTime? CreatedDate { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public float Weight { get; set; }

    }
}
