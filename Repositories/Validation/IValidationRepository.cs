namespace BookzoneProjNituDaniel.Repositories.Validation
{
    public interface IValidationRepository
    {
        bool UserExists(int userId);
        bool ProductExists(int productId);
    }
}
