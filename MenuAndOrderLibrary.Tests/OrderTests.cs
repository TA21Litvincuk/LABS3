using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MenuAndOrderLibrary.Tests
{
    // Тести для класу Order
    public class OrderTests
    {
        // Тест перевіряє, чи створюється замовлення з правильними властивостями
        [Fact]
        public void CreateOrder_ShouldInitializeWithCorrectValues()
        {
            var order = new Order(1);

            // Перевіряємо, чи замовлення має очікуваний ідентифікатор і статус
            Assert.Equal(1, order.OrderId);
            Assert.Equal("Очікує", order.Status);
        }

        // Тест перевіряє, чи правильно розраховується загальна вартість замовлення
        [Fact]
        public void CalculateTotal_ShouldReturnCorrectTotal()
        {
            var order = new Order(1);
            order.OrderedDishes.Add(new Dish("Burger", 10.0m));
            order.OrderedDishes.Add(new Dish("Fries", 3.0m));

            var total = order.CalculateTotal();

            // Перевіряємо, що сума правильна
            Assert.Equal(13.0m, total);
        }

        // Тест перевіряє, чи оновлюється статус замовлення
        [Fact]
        public void UpdateOrderStatus_ShouldChangeStatus()
        {
            var order = new Order(1);

            order.UpdateOrderStatus("Готується");

            // Перевіряємо, чи змінився статус
            Assert.Equal("Готується", order.Status);
        }
    }
}
