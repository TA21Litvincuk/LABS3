using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Клас, що представляє замовлення
    public class Order
    {
        public int OrderId { get; } // Унікальний ідентифікатор замовлення
        public List<Dish> OrderedDishes { get; } // Список страв у замовленні
        public string Status { get; private set; } // Поточний статус замовлення

        // Конструктор для створення замовлення
        public Order(int orderId)
        {
            OrderId = orderId; // Присвоюємо унікальний ідентифікатор
            OrderedDishes = new List<Dish>(); // Ініціалізуємо список страв
            Status = "Очікує"; // Початковий статус замовлення
        }

        // Оновлює статус замовлення
        public void UpdateOrderStatus(string newStatus)
        {
            // Перевірка дозволеної послідовності статусів
            if ((Status == "Очікує" && newStatus == "Готується") ||
                (Status == "Готується" && newStatus == "Готово"))
            {
                Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException("Неправильна послідовність оновлення статусу.");
            }
        }

        // Обчислює загальну вартість замовлення
        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var dish in OrderedDishes)
            {
                total += dish.Price; // Додаємо ціну кожної страви до загальної суми
            }
            return total; // Повертаємо загальну вартість
        }
    }
}
