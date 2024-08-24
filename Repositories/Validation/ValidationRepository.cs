using BookzoneProjNituDaniel.Data;

namespace BookzoneProjNituDaniel.Repositories.Validation
{
    public class ValidationRepository : IValidationRepository
    {
        private readonly DataContext _dataContext;

        public ValidationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool ProductExists(int productId)
        {
            return _dataContext.Products.Any(x=>x.Id == productId);
        }

        public bool UserExists(int userId)
        {
            return _dataContext.Users.Any(x => x.Id == userId);
        }
    }
}
