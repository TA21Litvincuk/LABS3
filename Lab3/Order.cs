﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Клас, що представляє замовлення
    public class Order
    {
        // Ідентифікатор замовлення
        public int OrderId { get; set; }

        // Список замовлених страв
        public List<Dish> OrderedDishes { get; set; } = new();

        // Поточний статус замовлення
        public string Status { get; set; } = "Очікує";

        // Конструктор для створення замовлення за його ідентифікатором
        public Order(int orderId)
        {
            OrderId = orderId;
        }

        // Метод для розрахунку загальної вартості замовлення
        public decimal CalculateTotal()
        {
            return OrderedDishes.Sum(d => d.Price); // Підсумовуємо ціни всіх страв
        }

        // Метод для оновлення статусу замовлення
        public void UpdateOrderStatus(string newStatus)
        {
            // Дозволені переходи між статусами
            var allowedTransitions = new Dictionary<string, string[]>
            {
                { "Очікує", new[] { "Готується" } },
                { "Готується", new[] { "Готово" } }
            };

            // Перевіряємо, чи можливий перехід у новий статус
            if (allowedTransitions.ContainsKey(Status) && allowedTransitions[Status].Contains(newStatus))
            {
                Status = newStatus; // Оновлюємо статус
            }
        }
    }
}
