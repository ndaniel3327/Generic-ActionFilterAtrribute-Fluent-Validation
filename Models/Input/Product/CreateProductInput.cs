namespace BookzoneProjNituDaniel.Models.Input.Product
{
    public class CreateProductInput : InputBase
    {
        public string Name { get; set; } = null!;
        public float Price { get; set; }
    }
}
