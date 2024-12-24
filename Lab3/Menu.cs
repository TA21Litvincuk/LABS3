using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Клас для управління меню ресторану
    public class Menu
    {
        // Приватний список усіх страв у меню
        private List<Dish> dishes = new();

        // Метод для додавання страви в меню
        public void AddDish(Dish dish)
        {
            // Перевіряємо, чи страва з такою назвою вже є в меню
            if (!dishes.Any(d => d.Name == dish.Name))
            {
                dishes.Add(dish); // Додаємо страву, якщо її немає
            }
        }

        // Метод для видалення страви з меню за назвою
        public void RemoveDish(string dishName)
        {
            // Знаходимо страву за назвою
            var dish = dishes.FirstOrDefault(d => d.Name == dishName);
            if (dish != null)
            {
                dishes.Remove(dish); // Видаляємо страву, якщо вона знайдена
            }
        }

        // Метод для отримання списку всіх страв у меню
        public List<Dish> GetDishes()
        {
            return dishes;
        }
    }
}
