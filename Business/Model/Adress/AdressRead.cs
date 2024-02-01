namespace Model.Adress
{
    public class AdressRead
    {
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int? Code { get; set; }
    }
}
