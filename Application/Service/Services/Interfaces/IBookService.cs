using Domain.Entities;
using Service.DTO_s.Book;
using Service.DTO_s.Product;

namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDTO book);
        Task<List<BookListDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookUpdateDTO book);
        Task<BookFindDTO> GetByIdAsync(int id);
        Task<List<BookListDTO>> SearchAsync(string? searchText);
    }
}
