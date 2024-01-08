using Api.Data.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Entity.Model
{
    public partial class Image
    {
        public Image()
        {
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }

        public string Front_image { get; set; } = null!;

        public string Full_image { get; set; } = null!;

        public string Side_image { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }

    }
}
