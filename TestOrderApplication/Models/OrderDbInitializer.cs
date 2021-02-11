using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class OrderDbInitializer : DropCreateDatabaseIfModelChanges<OrderDbContext>
    //DropCreateDatabaseIfModelChanges
    //DropCreateDatabaseAlways
    {
        protected override void Seed(OrderDbContext order)
        {
            var providers = new List<Provider>
            {
            new Provider{Name="Provider1"},
            new Provider{Name="Provider2"},
            new Provider{Name="Provider3"},
            new Provider{Name="Provider4"},
            new Provider{Name="Provider5"},
            new Provider{Name="Provider6"},
            new Provider{Name="Provider7"},
            new Provider{Name="Provider8"},
            new Provider{Name="Provider11"}
            };

            providers.ForEach(p => order.Provider.Add(p));
            //order.Provider.Add(new Provider { Id = 1, Name = "КЗМ"});
            order.SaveChanges();
            

            var orders = new List<Order>
            {
            new Order{Number = "1", Date = DateTime.Parse("2018-01-23 07:30:20"), ProviderId = 1 },
            new Order{Number = "11", Date = DateTime.Parse("2018-02-23 07:30:20"), ProviderId = 1 },
            new Order{Number = "111", Date = DateTime.Parse("2018-03-23 07:30:20"), ProviderId = 1 },
            new Order{Number = "1111", Date = DateTime.Parse("2018-04-23 07:30:20"), ProviderId = 1 },
            new Order{Number = "11111", Date = DateTime.Parse("2019-09-23 07:30:20"), ProviderId = 9 },
            new Order{Number = "2", Date = DateTime.Parse("2018-02-23 07:30:20"), ProviderId = 2 },
            new Order{Number = "3", Date = DateTime.Parse("2018-03-23 07:30:20"), ProviderId = 3 },
            new Order{Number = "4", Date = DateTime.Parse("2018-04-23 07:30:20"), ProviderId = 4 },
            new Order{Number = "5", Date = DateTime.Parse("2018-05-23 07:30:20"), ProviderId = 5 },
            new Order{Number = "6", Date = DateTime.Parse("2018-06-23 07:30:20"), ProviderId = 6 }
            };

            orders.ForEach(o => order.Order.Add(o));
            //order.Order.Add(new Order { Number = "1", Date = DateTime.Parse("2018-06-23 07:30:20"), ProviderId = 1 });
            order.SaveChanges();

            var orderItems = new List<OrderItem>
            {
            new OrderItem{Name = "Сталь", Quantity = 1.123m, Unit = "1", OrderId = 1},
            new OrderItem{Name = "Чугун", Quantity = 2.123m, Unit = "2", OrderId = 2},
            new OrderItem{Name = "Медь", Quantity = 3.123m, Unit = "3" , OrderId = 3},
            new OrderItem{Name = "Железо", Quantity = 4.123m, Unit = "4" , OrderId = 4},
            new OrderItem{Name = "Золото", Quantity = 5.123m, Unit = "5" , OrderId = 5},
            new OrderItem{Name = "Серебро", Quantity = 6.123m, Unit = "6" , OrderId = 6},
            new OrderItem{Name = "Бронза", Quantity = 7.123m, Unit = "7" , OrderId = 7},
            new OrderItem{Name = "Латунь", Quantity = 8.123m, Unit = "8" , OrderId = 8},
            new OrderItem{Name = "Бронза", Quantity = 1.123m, Unit = "1" , OrderId = 1},
            new OrderItem{Name = "Латунь", Quantity = 1.123m, Unit = "1" , OrderId = 1}
            };

            orderItems.ForEach(oI => order.OrderItem.Add(oI));
            //order.OrderItem.Add(new OrderItem { OrderId = 1, Name = "Сталь", Quantity = 1.123m, Unit = "1" });
            order.SaveChanges();

            //base.Seed(order);
        }

    }
}