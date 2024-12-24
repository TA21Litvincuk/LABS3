using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab3
{
    public class OrderManager
    {
        private List<Order> orders; // Список усіх замовлень

        public OrderManager()
        {
            orders = new List<Order>(); // Ініціалізуємо список замовлень
        }

        // Створює нове замовлення з унікальним ідентифікатором
        public void CreateOrder(int orderId)
        {
            orders.Add(new Order(orderId)); // Додаємо нове замовлення до списку
        }

        // Додає страву до конкретного замовлення
        public void AddDishToOrder(int orderId, Dish dish)
        {
            var order = orders.Find(o => o.OrderId == orderId); // Знаходимо замовлення за ID
            if (order != null)
            {
                order.OrderedDishes.Add(dish); // Додаємо страву до списку страв замовлення
            }
        }

        // Видаляє страву з конкретного замовлення за назвою
        public void RemoveDishFromOrder(int orderId, string dishName)
        {
            var order = orders.Find(o => o.OrderId == orderId); // Знаходимо замовлення за ID
            if (order != null)
            {
                order.OrderedDishes.RemoveAll(d => d.Name == dishName); // Видаляємо страву зі списку
            }
        }

        // Отримує статус конкретного замовлення
        public string GetOrderStatus(int orderId)
        {
            var order = orders.Find(o => o.OrderId == orderId); // Знаходимо замовлення за ID
            return order != null ? order.Status : null; // Повертаємо статус замовлення або null
        }
    }
}
