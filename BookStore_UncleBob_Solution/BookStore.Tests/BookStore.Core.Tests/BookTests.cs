using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.BookStore.Core.Tests
{
    public class BookTests
    {
        [Fact]
        public void GetDiscountedPrice_ShouldCalculateCorrectly_WhenValidDiscountPercentage()
        {
            // Arrange
            var book = new Book
            {
                Price = 100m
            };

            var discountPercentage = 10m;
            var expectedPrice = 90m; // 100 - (100 * 10 / 100)

            // Act
            var discountedPrice = book.GetDiscountedPrice(discountPercentage);

            // Assert
            Assert.Equal(expectedPrice, discountedPrice);
        }

        [Fact]
        public void GetDiscountedPrice_ShouldThrowArgumentException_WhenInvalidDiscountPercentage()
        {
            // Arrange
            var book = new Book
            {
                Price = 100m
            };

            var discountPercentage = -10m; // Invalid discount percentage

            // Act & Assert
            Assert.Throws<ArgumentException>(() => book.GetDiscountedPrice(discountPercentage));
        }
    }
}
