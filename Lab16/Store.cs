using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab16
{
    public static class Rand
    {
        public static Random Random = new Random();
    }
    class Product
    {
        private int _cost;
        private string _name;
        public int GetCost { get{ return _cost; }}
        public string GetName { get{ return _name; }}
        public Product()
        {
            _name = "No Name";
            _cost = 0;
        }
        public Product(string name,int cost)
        {
            _name = name;
            _cost = cost;
        }
    }

    class Provider
    {
        public string name;
        public Product production;

        public Provider()
        {
            name = "No Name Company";
            production = new Product("Something",5);
        }
        public Provider(string compName,string prodName,int prodCost)
        {
            name = compName;
            production = new Product(prodName,prodCost);
        }

        public void ToStore(ref Store store)
        {
            Thread.Sleep(Rand.Random.Next(500, 1300));

            if (store.products.TryAdd(production, 1000))
                Console.WriteLine($"!{store.name} received {production.GetName} from {name}\n");
            else
                Console.WriteLine($"!{store.name} didn't receive {production.GetName} from {name}\n");
        }
    }

    class Customer
    {
        public string name;
        public Customer()
        {
            name = "No Name Customer";
        }
        public Customer(string customerName)
        {
            name = customerName;
        }

        public void FromShop(ref Store store)
        {
            Thread.Sleep(Rand.Random.Next(1000, 2000));

            Product product;
            
            if (store.products.TryTake(out product, 1))
                Console.WriteLine($"!{name} buy {product.GetName} from {store.name}\n");
            else
                Console.WriteLine($"!{name} don't buy anything\n");
        }
    }

    class Store
    {
        public string name;
        public BlockingCollection<Product> products = new BlockingCollection<Product>();

        public Store()
        {
            name = "No name Store";
        }
        public Store(string storeName)
        {
            name = storeName;
        }
    }


    class EmulatorOfStore
    {
        Store Store = new Store("Brusnichka");
        Provider[] providers =
        {
            new Provider("Lenovo","Laptop",100),
            new Provider("Philips","TV",60),
            new Provider("MilkCorp","Milk",5),
            new Provider("Printer","Book",9),
            new Provider("CoCo","Clother",3)
        };

        Customer[] customers =
        {
            new Customer(),
            new Customer("Danil"),
            new Customer("Maks"),
            new Customer("Misha"),
            new Customer("Sanya"),
            new Customer("Dima"),
            new Customer("Lera"),
            new Customer("Kate"),
            new Customer("Julia"),
            new Customer("Alex")
        };
        public void Start()
        {
            Task taskCust = new Task(()=>Cust());
            Task taskProv = new Task(()=>Prov());
            taskProv.Start();
            taskCust.Start();
            Task.WaitAll(taskCust, taskProv);
        }

        public void helpCust(Customer customer)
        {
            customer.FromShop(ref Store);
            printState();
        }
        public void helpProv(Provider provider)
        {
            provider.ToStore(ref Store);
            printState();
        }

        public void Cust()
        {
            for (int i = 0; i < 4; i++)
            Parallel.ForEach<Customer>(customers,helpCust);
        }
        public void Prov()
        {
            for (int i = 0; i < 5; i++)
                Parallel.ForEach<Provider>(providers, helpProv);
        }

        public void printState()
        {
            string outstr = "";
            foreach (Product product in Store.products)
            {
                outstr += product.GetName + '\n';
            }
            Console.WriteLine(outstr);
        }
    }

}
