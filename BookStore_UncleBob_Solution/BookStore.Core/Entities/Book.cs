using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities
{
    public partial class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int? NumberOfPages { get; set; }

        public DateTime? PublishedDate { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public bool? IsDiscounted { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

        public decimal GetDiscountedPrice(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Invalid discount percentage");
            }
            return Price - (Price * discountPercentage / 100);
        }
    }
}
