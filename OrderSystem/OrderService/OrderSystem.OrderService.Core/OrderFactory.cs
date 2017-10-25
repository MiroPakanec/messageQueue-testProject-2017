using DTOs;
using System;
using System.Collections.Generic;
using Utilities;

namespace Core
{
    internal class OrderFactory
    {
        private static int itemId = 0;

        internal static Order CreateOrder
        {
            get
            {
                Category cat1 = new Category() { Id = 0, Name = "Gadget", StartDate = DateTime.Now.AddDays(-275), EndDate = DateTime.Now.AddDays(675) };
                Category cat2 = new Category() { Id = 1, Name = "Widget", StartDate = DateTime.Now.AddDays(-275), EndDate = null };

                Item item = new Item() { Id = itemId++, Price = 23.1, Name = "thing", Category = cat1 };
                Item item2 = new Item() { Id = itemId++, Price = 432, Name = "thang", Category = cat2 };

                PersonAuth pauth;
                var rand = new Random().Next(0, 4);

                switch (rand)
                {
                    case 0:
                    {
                        pauth = new PersonAuth() { Id = 1, Password = "123123", Username = "Miroslav-Pakanec" };
                        break;
                    }
                    case 1: {
                        pauth = new PersonAuth() { Id = 2, Password = "hansiHinter", Username = "Hansi" };
                        break;
                    }
                    case 2:
                    {
                        pauth = new PersonAuth() { Id = 2, Password = "hansiHinter", Username = "Hansii" };
                        break;
                    }
                    default:
                    {
                        pauth = new PersonAuth() { Id = 2, Password = "hansiHinterr", Username = "Hansi" };
                        break;
                    }
                }

                SalesItem sales = new SalesItem() { SalesId = 0, Product = item, ReservationDate = DateTime.Now, Quantity = 4 };
                SalesItem sales2 = new SalesItem() { SalesId = 0, Product = item2, ReservationDate = DateTime.Now, Quantity = 1 };

                string comments = LoremIpsum.CreateRandom();

                Order order = new Order()
                {
                    OrderId = 0,
                    Customer = new Customer() { Id = 12345, Name = "Chingo", Company = "ToysRus" },
                    ConfirmationDate = DateTime.Now
                    ,
                    ResponsibleSeller = pauth,
                    OrderLines = new List<SalesItem>() { sales, sales2 },
                    Comments = comments
                };

                return order;
            }
        }
    }
}
