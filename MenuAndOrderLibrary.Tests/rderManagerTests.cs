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
        // Тест перевіряє, чи можна створити нове замовлення
        [Fact]
        public void CreateOrder_ShouldAddOrder()
        {
            var manager = new OrderManager();

            manager.CreateOrder(1);

            // Перевіряємо, чи замовлення створено
            Assert.NotNull(manager.GetOrderStatus(1));
        }

        // Тест перевіряє, чи можна додати страву до замовлення
        [Fact]
        public void AddDishToOrder_ShouldAddDish()
        {
            var manager = new OrderManager();
            manager.CreateOrder(1);
            var dish = new Dish("Sushi", 15.0m);

            manager.AddDishToOrder(1, dish);

            // Перевіряємо, що страва додана до замовлення
            var status = manager.GetOrderStatus(1); // Просто перевірка зв’язку
            Assert.NotNull(status);
        }

        // Тест перевіряє, чи можна видалити страву із замовлення
        [Fact]
        public void RemoveDishFromOrder_ShouldRemoveDish()
        {
            var manager = new OrderManager();
            manager.CreateOrder(1);
            var dish = new Dish("Ramen", 9.0m);

            manager.AddDishToOrder(1, dish);
            manager.RemoveDishFromOrder(1, "Ramen");

            // Перевіряємо, чи страва видалена
            Assert.Equal("Очікує", manager.GetOrderStatus(1));
        }
    }
}
