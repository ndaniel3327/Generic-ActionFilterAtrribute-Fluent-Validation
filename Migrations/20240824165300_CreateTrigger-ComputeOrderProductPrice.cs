using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookzoneProjNituDaniel.Migrations
{
    /// <inheritdoc />
    public partial class CreateTriggerComputeOrderProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_UpdateOrderProductsPrice
            ON dbo.OrderProducts
            AFTER INSERT, UPDATE
            AS
            BEGIN
                UPDATE op
                SET op.Price = p.Price
                FROM dbo.OrderProducts op
                INNER JOIN dbo.Products p ON op.ProductId = p.Id
                WHERE op.Id IN (SELECT Id FROM inserted);
            END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_UpdateOrderProductsPrice;");
        }
    }
}
