using Service.DTO_s.Product;

namespace Service.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDTO product);
        Task<List<ProductListDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, ProductUpdateDTO product);
        Task<ProductFindDTO> GetByIdAsync(int id);
        Task<List<ProductListDTO>> SearchAsync(string? searchText);
    }
}