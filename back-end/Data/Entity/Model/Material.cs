namespace Api.Data.Context.Model;

public partial class Material
{
    public int Id { get; set; }
    public string Label { get; set; } = null!;
    public virtual ICollection<Item>? Items { get; set; }
}
