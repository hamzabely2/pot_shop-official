namespace Model.Cart;
using Entity.Model;

public class ReadCart
{
    public int Id { get; set; }

    public int Quantity { get;set; }

    public CartItem Item { get; set; }

}
