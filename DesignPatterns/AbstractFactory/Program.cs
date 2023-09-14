using AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Log4NetLogger;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }
}

public class Log4NetLogger : Logging
{
    public override void Log(string message)
    {
        Console.WriteLine("Logged with log4net");
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Memcache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Memcache");
        }
    }

    public abstract class CCCFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CCCFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CCCFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CCCFactory _cccFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CCCFactory cccFactory)
        {
            _cccFactory = cccFactory;
            _logging = _cccFactory.CreateLogger();
            _caching = _cccFactory.CreateCaching();
        }
    

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products listed");

        }
    }
}

