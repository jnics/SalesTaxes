public interface IItem
{
    public string Name { get; init; }
    public double Price { get; set; }
    public double TaxAmount { get; set; }
    public int Quantity { get; set; }
}