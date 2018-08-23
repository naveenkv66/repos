using System;
using System.Linq;
using System.Collections.Generic;

namespace IIHT.Linq
{
    public class OrderItem
    {
        public Order Order { get; set; }
        public Item Item { get; set; }

    }
    public class Item
    {
        public string ItemName { get; set; }

        public decimal Price { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }

        public string ItemName { get; set; }
        public DateTime OrderDate { get; set; }
        public int quantity { get; set; }
    }
    public class Player
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Team { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Excersise1();
                Excersise2();
                Excersise3();
                Excersise4();
                Excersise5();
                Excersise6();
                Excersise7();
                Excersise8();
                Excersise9();
            }
            catch (Exception ex)
            {

            }

        }

        static List<Order> GetOrders()
        {
            return new List<Order>()
            {
                new Order(){OrderId=1,OrderDate=new DateTime(2018,7,18),ItemName="product1",quantity=2},
                new Order(){OrderId=2,OrderDate=new DateTime(2018,7,18),ItemName="product2",quantity=4},
                new Order(){OrderId=3,OrderDate=new DateTime(2018,6,22),ItemName="product3",quantity=2},
                new Order(){OrderId=4,OrderDate=new DateTime(2018,7,24),ItemName="product4",quantity=5},
                new Order(){OrderId=5,OrderDate=new DateTime(2018,7,24),ItemName="product5",quantity=4},
                new Order(){OrderId=6,OrderDate=new DateTime(2018,8,3),ItemName="product6",quantity=2},
            };

        }
        static List<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item(){ItemName="product1",Price=10},
                new Item(){ItemName="product2",Price=200},
                new Item(){ItemName="product3",Price=140},
                new Item(){ItemName="product4",Price=18.9m},
                new Item(){ItemName="product5",Price=17},
                new Item(){ItemName="product6",Price=120},


            };

        }

        static List<Player> GetPlayes()
        {
            List<Player> players = new List<Player>()
            {
                new Player(){Name="Denis Shapovalov",Country="Canada"},
                new Player(){Name="Milos Raonic",Country="Canada"},
                new Player(){Name="Vasek Pospisil",Country="Canada"},

                new Player(){Name="John Isner",Country="USA"},
                new Player(){Name="Sam Querrey",Country="USA"},
                new Player(){Name="Steve Johnson",Country="USA"},
                new Player(){Name="Bradley Klahn",Country="USA"},

                new Player(){Name="Ramkumar Ramanathan",Country="India"},
                new Player(){Name="Prajnesh Gunneswaran",Country="India"},
                new Player(){Name="Yuki Bhambri",Country="India"},

                new Player(){Name="Nick Kyrgios",Country="Australia"},
                new Player(){Name="John Millman",Country="Australia"},
                new Player(){Name="Matthew Ebden",Country="Australia"},
                new Player(){Name="Alex de Minaur",Country="Australia"},
                new Player(){Name="Jason Kubler",Country="Australia"},

                new Player(){Name="Roger Federer",Country="Switzerland"},
                new Player(){Name="Henri Laaksonen",Country="Switzerland"},
                new Player(){Name="Adrian Bodmer",Country="Switzerland"},
                new Player(){Name="Yann Marti",Country="Switzerland"},
                new Player(){Name="Stan Wawrinka",Country="Switzerland"},

                new Player(){Name="Gonzalo Lama",Country="Chile"},
                new Player(){Name="Victor Nunez",Country="Chile"},
                new Player(){Name="Esteban Bruna",Country="Chile"},
                 new Player(){Name="Christian Garin",Country="Chile"},
            };
            return players;

        }
        static void PrintCubeOfNumbers(int[] numbers)
        {
            var Cubeofnumbers = (from int num in numbers
                                 let cubeNo = num * num * num
                                 where cubeNo > 100 && cubeNo < 1000
                                 select new { num, cubeNo }).ToList();

            Cubeofnumbers.ForEach(item =>
            {
                Console.WriteLine("Number: " + item.num + " Cube: " + item.cubeNo);
            });
            Console.ReadLine();
        }
        static void PrintPossibleMatches(List<Player> TeamA, List<Player> TeamB)
        {
            Console.WriteLine("Team A : " + string.Join(",", TeamA.Select(x => x.Name + " (" + x.Country + ")")));
            Console.WriteLine("Team B : " + string.Join(",", TeamB.Select(x => x.Name + " (" + x.Country + ")")));
            Console.WriteLine();
            Console.WriteLine("Possible Tennis Matches");
            Console.WriteLine();
            TeamA.ForEach(item1 =>
            {
                TeamB.ForEach(item2 =>
                {
                    if (item1.Country != item2.Country)
                    {
                        Console.WriteLine(item1.Name + "(A)" + "(" + item1.Country + ")" + " vs " + item2.Name + "(B)" + "(" + item2.Country + ")");
                    }

                });
                Console.WriteLine();

            });
            Console.ReadLine();
        }
        static void CountAndDisplayEvenNumber(int[] numbers)
        {
            var evenNumbers = numbers.ToList().FindAll(item => item % 2 == 0);
            var count = evenNumbers.Count();
            Console.WriteLine("Given Numbers: " + string.Join(",", numbers));

            Console.WriteLine("Even Numbers: " + string.Join(",", evenNumbers));
            Console.WriteLine("Even Numbers Count: " + count);


        }

        static void Excersise1()
        {
            var Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Console.WriteLine("Excersise1");
            Console.WriteLine("Array of Numbers: " + string.Join(",", Numbers));
            Console.WriteLine("Output: Cube of the numbers that are greater than 100 but less than 1000");
            PrintCubeOfNumbers(Numbers);
            var ModifiedNumbers = new int[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            Console.WriteLine("Array of Modified Numbers: " + string.Join(",", ModifiedNumbers));
            Console.WriteLine("Output: Cube of the numbers that are greater than 100 but less than 1000");
            PrintCubeOfNumbers(ModifiedNumbers);
        }
        static void Excersise2()
        {
            Console.WriteLine("Excersise2");
            var players = GetPlayes();
            var shuffledPlayers = players.OrderBy(a => Guid.NewGuid()).ToList();
            var halfWay = shuffledPlayers.Count / 2;
            var TeamA = shuffledPlayers.Take(halfWay).ToList();
            var TeamB = shuffledPlayers.Skip(halfWay).ToList();
            PrintPossibleMatches(TeamA, TeamB);
        }
        static void Excersise3()
        {
            Console.WriteLine("Excersise3");
            var Orders = GetOrders();
            //    List<string> columns = new List<string>() { "Orderid", "ItemName", "OrderDate", "Quantity" };
            var SortedOrders = Orders.OrderByDescending(item => item.OrderDate).ThenByDescending(item => item.quantity).ToList();

            Console.WriteLine("{0,4}{1,14}{2,16}{3,10}",
                    "Id", "ItemName", "OrderDate", "Quantity");
            Console.WriteLine();
            SortedOrders.ForEach(item =>
            {
                Console.WriteLine("{0,4}{1,14}{2,16}{3,5}",
                                   item.OrderId, item.ItemName, item.OrderDate.Date.ToShortDateString(), item.quantity);
            });
        }
        static void Excersise4()
        {
            var Orders = GetOrders();
            Console.WriteLine("Excersise4");
            var ordersByMonth = (from ordr in Orders
                                 group ordr by ordr.OrderDate.Month into o
                                 orderby o.Key descending

                                 select o).ToList();

            Console.WriteLine();

            Console.WriteLine("Group By Month");
            Console.WriteLine();
            ordersByMonth.ForEach(item =>
            {
                Console.WriteLine($"Month: {item.Key}");
                Console.WriteLine();
                Console.WriteLine("{0,4}{1,14}{2,16}{3,10}",
                    "Id", "ItemName", "OrderDate", "Quantity");
                foreach (var order in item.OrderByDescending(x => x.OrderDate).ThenByDescending(y => y.quantity))
                {
                    Console.WriteLine("{0,4}{1,14}{2,16}{3,5}",
                                   order.OrderId, order.ItemName, order.OrderDate.Date.ToShortDateString(), order.quantity);
                }

            });

            Console.ReadLine();
            Console.WriteLine();
        }
        static void Excersise5()
        {
            Console.WriteLine("Excersise5");
            var items = GetItems();
            var Orders = GetOrders();
            var result = (from ordr in Orders
                          join item in items
                          on ordr.ItemName equals item.ItemName
                          select new OrderItem
                          {
                              Order = ordr,
                              Item = item
                          } into joinResult
                          group joinResult by joinResult.Order.OrderDate.Month into groupResult
                          orderby groupResult.Key descending
                          select groupResult
                         ).ToList();
            result.ForEach(ordrGroups =>
            {
                Console.WriteLine($"Month: {ordrGroups.Key}");
                Console.WriteLine();
                Console.WriteLine("{0,4}{1,14}{2,16}{3,11}{4,15}",
                    "Id", "ItemName", "OrderDate", "Quantiy", "TotalPrice");
                foreach (var order in ordrGroups.OrderByDescending(x => x.Order.OrderDate).ThenByDescending(y => y.Order.quantity))
                {
                    Console.WriteLine("{0,4}{1,14}{2,16}{3,5}{4,15}",
                                   order.Order.OrderId, order.Item.ItemName, order.Order.OrderDate.Date.ToShortDateString(), order.Order.quantity, order.Order.quantity * order.Item.Price);
                }


            });
            Console.WriteLine();
        }
        static void Excersise6()
        {
            Console.WriteLine("Excersise6");

            var Orders = GetOrders();
            var Items = GetItems();
            var result = (from ordr in Orders
                          join item in Items
                          on ordr.ItemName equals item.ItemName
                          select new
                          {
                              Order = ordr,
                              Item = item
                          } into joinResult
                          group joinResult by joinResult.Order.OrderDate.Month into groupResult
                          orderby groupResult.Key descending
                          select groupResult
                         ).ToList();
            result.ForEach(ordrGroups =>
            {
                Console.WriteLine($"Month: {ordrGroups.Key}");
                Console.WriteLine();
                Console.WriteLine("{0,4}{1,14}{2,16}{3,11}{4,15}",
                    "Id", "ItemName", "OrderDate", "Quantiy", "TotalPrice");
                foreach (var order in ordrGroups.OrderByDescending(x => x.Order.OrderDate).ThenByDescending(y => y.Order.quantity))
                {
                    Console.WriteLine("{0,4}{1,14}{2,16}{3,5}{4,15}",
                                   order.Order.OrderId, order.Item.ItemName, order.Order.OrderDate.Date.ToShortDateString(), order.Order.quantity, order.Order.quantity * order.Item.Price);
                }


            });

            Console.ReadLine();
        }
        static void Excersise7()
        {
            Console.WriteLine("Excersise7");
            var orders = GetOrders();
            bool QuantitesinOrderCollectionGreaterThanZero = orders.TrueForAll(item => item.quantity > 0);
            string orderWithMaxQuantiy = orders.OrderByDescending(x => x.quantity).FirstOrDefault()?.ItemName;
            bool orderPlacedBeforejanuary = orders.Where(x => x.OrderDate.Year == DateTime.Now.Year).Any(x => x.OrderDate.Month < 1);
            Console.WriteLine($"there are any orders placed before Jan of this yearollection is >0: {orderPlacedBeforejanuary}");
            Console.WriteLine($"Check if all the quantities in the Order collection is >0 : {QuantitesinOrderCollectionGreaterThanZero}");
            Console.WriteLine($"name of the item that was ordered in largest quantity in a single order: {orderWithMaxQuantiy}");
            Console.WriteLine();
            Console.WriteLine("Excersise9");
        }
        static void Excersise8()
        {

        }
        static void Excersise9()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            CountAndDisplayEvenNumber(numbers);
            Console.ReadLine();
        }
    }
}
