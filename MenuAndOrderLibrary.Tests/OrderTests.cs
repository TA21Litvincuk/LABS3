using Lab3;
using Xunit;

namespace MenuAndOrderLibrary.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_CanBeCreated_WithValidProperties()
        {
            // Arrange
            int orderId = 1;

            // Act
            var order = new Order(orderId);

            // Assert
            Assert.Equal(1, order.OrderId);
            Assert.Empty(order.OrderedDishes);
            Assert.Equal("Очікує", order.Status);
        }

        [Fact]
        public void CanAddDishToOrder()
        {
            // Arrange
            var order = new Order(1);
            var dish = new Dish("Pizza", 12.99m);

            // Act
            order.AddDish(dish);

            // Assert
            Assert.Single(order.OrderedDishes);
            Assert.Equal("Pizza", order.OrderedDishes[0].Name);
        }

        [Fact]
        public void CanRemoveDishFromOrder()
        {
            // Arrange
            var order = new Order(1);
            var dish = new Dish("Pizza", 12.99m);
            order.AddDish(dish);

            // Act
            order.RemoveDish("Pizza");

            // Assert
            Assert.Empty(order.OrderedDishes);
        }

        [Fact]
        public void CanGetOrderStatus()
        {
            // Arrange
            var order = new Order(1);

            // Act
            var status = order.GetStatus();

            // Assert
            Assert.Equal("Очікує", status);
        }

        [Fact]
        public void CanUpdateOrderStatus()
        {
            // Arrange
            var order = new Order(1);

            // Act
            order.UpdateStatus("Готується");

            // Assert
            Assert.Equal("Готується", order.Status);
        }
    }
}
