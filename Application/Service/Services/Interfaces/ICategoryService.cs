using Service.DTO_s.Category;
using Service.DTO_s.Product;

namespace Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryDTO category);
        Task<List<CategoryDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, CategoryDTO category);
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<List<CategoryDTO>> SearchAsync(string? searchText);
    }
}
