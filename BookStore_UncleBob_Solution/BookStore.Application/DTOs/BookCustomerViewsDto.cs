using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs
{
    public class BookCustomerViewsDto
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
