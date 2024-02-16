using Context.Interface;
using Entity.Model;

namespace Test.Common
{
    public static class ItemData
    {
        public static void CreateItem(this PotShopIDbContext idbContext)
        {
            var item1 = new Item
            {
                Id = 1,
                Name = "vase",
                Price = 30,
                Description = "description vase",
                CategoryId = 1,
                MaterialId = 1,
                Stock = 55
            };
            var item2 = new Item
            {
                Id = 2,
                Name = "tagin",
                Price = 20,
                Description = "description tagin",
                CategoryId = 1,
                MaterialId = 1,
                Stock = 55
            };
            idbContext.Items.AddRange(item1, item2);
            idbContext.SaveChanges();
        }
    }
}
