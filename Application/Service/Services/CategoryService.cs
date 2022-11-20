using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTO_s.Category;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDTO category)
        {
            await _repository.Create(_mapper.Map<Category>(category));
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.Get(id);

            await _repository.Delete(category);
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryDTO>>(await _repository.GetAll());
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CategoryDTO>(await _repository.Get(id));
        }

        public async Task<List<CategoryDTO>> SearchAsync(string? searchText)
        {
            List<Category> searchDatas = new();

            if (searchText != null)
            {
                searchDatas = await _repository.FindAllByExpressionAsync(m => m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repository.GetAll();
            }

            return _mapper.Map<List<CategoryDTO>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repository.Get(id);

            await _repository.SoftDelete(category);
        }

        public async Task UpdateAsync(int id, CategoryDTO category)
        {
            var dbCategory = await _repository.Get(id);

            _mapper.Map(category, dbCategory);

            await _repository.Update(dbCategory);
        }
    }
}
