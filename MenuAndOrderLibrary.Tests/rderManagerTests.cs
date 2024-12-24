using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MenuAndOrderLibrary.Tests
{
    public class OrderManagerTests
    {
        [Fact]
        public void CanCreateAndRetrieveOrder()
        {
            // Arrange
            var manager = new OrderManager();

            // Act
            manager.CreateOrder(1);
            var order = manager.GetOrder(1);

            // Assert
            Assert.NotNull(order);
            Assert.Equal(1, order.OrderId);
        }

        [Fact]
        public void AddingDishToNonexistentOrderThrowsException()
        {
            // Arrange
            var manager = new OrderManager();
            var dish = new Dish("Pizza", 12.99m);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => manager.AddDishToOrder(1, dish));
            Assert.Equal("Order with ID 1 does not exist.", exception.Message);
        }


        [Fact]
        public void CanAddAndRemoveDishesFromOrder()
        {
            // Arrange
            var manager = new OrderManager();
            var dish = new Dish("Pizza", 12.99m);
            manager.CreateOrder(1);

            // Act
            manager.AddDishToOrder(1, dish);
            manager.RemoveDishFromOrder(1, "Pizza");

            // Assert
            var order = manager.GetOrder(1);
            Assert.Empty(order.OrderedDishes);
        }

        [Fact]
        public void GettingStatusForNonexistentOrderThrowsException()
        {
            // Arrange
            var manager = new OrderManager();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => manager.GetOrderStatus(1));
            Assert.Equal("Order with ID 1 does not exist.", exception.Message);
        }
    }
}
