namespace BookzoneProjNituDaniel.Models.DTO.Product
{
    public class ProductReportDTO
    {
        public string ProductName { get; set; } = null!;
        public int UnitsSold { get; set; }
        public float TotalIncomeGenerated { get; set; }
    }
}
