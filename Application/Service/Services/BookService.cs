using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTO_s.Book;
using Service.DTO_s.Product;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDTO book)
        {
            await _repository.Create(_mapper.Map<Book>(book));
        }

        public async Task<List<BookListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<BookListDTO>>(await _repository.GetAll());
        }

        public async Task DeleteAsync(int id)
        {
            Book book = await _repository.Get(id);

            await _repository.Delete(book);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Book book = await _repository.Get(id);

            await _repository.SoftDelete(book);
        }

        public async Task UpdateAsync(int id, BookUpdateDTO book)
        {
            var dbBook = await _repository.Get(id);

            _mapper.Map(book, dbBook);

            await _repository.Update(dbBook);
        }

        public async Task<List<BookListDTO>> SearchAsync(string? searchText)
        {
            List<Book> searchDatas = new();

            if (searchText != null)
            {
                searchDatas = await _repository.FindAllByExpressionAsync(m => m.Name.Contains(searchText) &&
                m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repository.GetAll();
            }

            return _mapper.Map<List<BookListDTO>>(searchDatas);
        }

        public async Task<BookFindDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<BookFindDTO>(await _repository.Get(id));
        }
    }
}
