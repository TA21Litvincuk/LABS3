using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab3
{
    // Клас для управління замовленнями
    public class OrderManager
    {
        // Приватний список усіх замовлень
        private List<Order> orders = new();

        // Метод для створення нового замовлення
        public void CreateOrder(int orderId)
        {
            // Створюємо замовлення і додаємо його до списку
            var order = new Order(orderId);
            orders.Add(order);
        }

        // Метод для додавання страви до замовлення
        public void AddDishToOrder(int orderId, Dish dish)
        {
            // Знаходимо замовлення за ідентифікатором
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.OrderedDishes.Add(dish); // Додаємо страву до замовлення
            }
        }

        // Метод для видалення страви з замовлення
        public void RemoveDishFromOrder(int orderId, string dishName)
        {
            // Знаходимо замовлення за ідентифікатором
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                // Знаходимо страву в списку замовлення
                var dish = order.OrderedDishes.FirstOrDefault(d => d.Name == dishName);
                if (dish != null)
                {
                    order.OrderedDishes.Remove(dish); // Видаляємо страву
                }
            }
        }

        // Метод для отримання статусу замовлення
        public string GetOrderStatus(int orderId)
        {
            // Знаходимо замовлення за ідентифікатором і повертаємо його статус
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            return order?.Status ?? "Замовлення не знайдено";
        }
    }
}
