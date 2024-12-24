using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MenuAndOrderLibrary.Tests
{
    // ����� ��� ����� Order
    public class OrderTests
    {
        // ���� ��������, �� ����������� ���������� � ����������� �������������
        [Fact]
        public void CreateOrder_ShouldInitializeWithCorrectValues()
        {
            var order = new Order(1);

            // ����������, �� ���������� �� ���������� ������������� � ������
            Assert.Equal(1, order.OrderId);
            Assert.Equal("�����", order.Status);
        }

        // ���� ��������, �� ��������� ������������� �������� ������� ����������
        [Fact]
        public void CalculateTotal_ShouldReturnCorrectTotal()
        {
            var order = new Order(1);
            order.OrderedDishes.Add(new Dish("Burger", 10.0m));
            order.OrderedDishes.Add(new Dish("Fries", 3.0m));

            var total = order.CalculateTotal();

            // ����������, �� ���� ���������
            Assert.Equal(13.0m, total);
        }

        // ���� ��������, �� ����������� ������ ����������
        [Fact]
        public void UpdateOrderStatus_ShouldChangeStatus()
        {
            var order = new Order(1);

            order.UpdateOrderStatus("��������");

            // ����������, �� ������� ������
            Assert.Equal("��������", order.Status);
        }
    }
}
