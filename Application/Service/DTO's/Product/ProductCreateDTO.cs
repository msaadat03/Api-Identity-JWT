namespace Service.DTO_s.Product
{
    public class ProductCreateDTO
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
    }
}
