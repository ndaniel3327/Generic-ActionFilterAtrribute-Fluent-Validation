namespace BookzoneProjNituDaniel.Models.Input.Product
{
    public class UpdateProductInput : InputBase
    {
        public string Name { get; set; } = null!;
        public float Price { get; set; }
    }
}
