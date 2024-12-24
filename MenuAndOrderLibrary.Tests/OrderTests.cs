using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MenuAndOrderLibrary.Tests
{
    public class OrderTests
    {
        [Fact]
        public void CalculateTotal_ShouldReturnCorrectTotal()
        {
            // Arrange
            var order = new Order(1);
            order.OrderedDishes.Add(new Dish("Суп", 50.5m)); // Передаємо аргументи в конструктор
            order.OrderedDishes.Add(new Dish("Салат", 30.25m)); // Передаємо аргументи в конструктор

            // Act
            var total = order.CalculateTotal();

            // Assert
            Assert.Equal(80.75m, total); // Загальна вартість повинна бути 80.75
        }

        [Fact]
        public void UpdateOrderStatus_ShouldUpdateStatusCorrectly()
        {
            // Arrange
            var order = new Order(1);

            // Act
            order.UpdateOrderStatus("Готується");
            order.UpdateOrderStatus("Готово");

            // Assert
            Assert.Equal("Готово", order.Status); // Статус повинен оновитися до "Готово"
        }

        [Fact]
        public void UpdateOrderStatus_InvalidSequence_ShouldThrowException()
        {
            // Arrange
            var order = new Order(1);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => order.UpdateOrderStatus("Готово")); // Неправильна послідовність
        }
    }
}
