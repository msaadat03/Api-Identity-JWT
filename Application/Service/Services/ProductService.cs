using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTO_s.Product;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductCreateDTO product)
        {
            await _repository.Create(_mapper.Map<Product>(product));
        }

        public async Task<List<ProductListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<ProductListDTO>>(await _repository.GetAll());
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _repository.Get(id);

            await _repository.Delete(product);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Product product = await _repository.Get(id);

            await _repository.SoftDelete(product);
        }

        public async Task UpdateAsync(int id, ProductUpdateDTO product)
        {
            var dbProduct = await _repository.Get(id);

            _mapper.Map(product, dbProduct);

            await _repository.Update(dbProduct);
        }

        public async Task<List<ProductListDTO>> SearchAsync(string searchText)
        {
            List<Product> searchDatas = new();

            if(searchText != null)
            {
                searchDatas = await _repository.FindAllByExpressionAsync(m => m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repository.GetAll();
            }

            return _mapper.Map<List<ProductListDTO>>(searchDatas);
        }

        public async Task<ProductFindDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ProductFindDTO>(await _repository.Get(id));
        }
    }
}