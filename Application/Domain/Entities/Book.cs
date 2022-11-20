using Domain.Common;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
