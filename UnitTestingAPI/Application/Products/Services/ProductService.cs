namespace UnitTestingAPI.Application.Products.Services;

public class ProductService : IProductService
{
    private readonly DatabaseContext _databaseContext;

	public ProductService(DatabaseContext databaseContext)
	{
		_databaseContext = databaseContext;
	}

	public async Task<Result<Product>> GetByIdAsync(int id)
	{
		var product = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync( p => p.Id == id);

		if (product == null)
		{
			return "ERROR_CODE_G1"
		}

		return product;
	}
}