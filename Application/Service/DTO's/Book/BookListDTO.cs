using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO_s.Book
{
    public class BookListDTO
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
