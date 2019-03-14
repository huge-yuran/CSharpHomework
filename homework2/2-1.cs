using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1
{
    public interface Log
    {
        void Write();
    }

    class File : Log
    {
        public void Write()
        {
            Console.WriteLine("文件-日志");
        }
    }

    class Database : Log
    {
        public void Write()
        {
            Console.WriteLine("数据库-日志");
        }
    }

    public interface Factory
    {
        Log CreateLog();
    }

    class FileLogFactory : Factory
    {
        public Log CreateLog()
        {
            Log log = new File();
            return log;
        }
    }

    class DatabaseLogFactory : Factory
    {
        public Log CreateLog()
        {
            Log log = new Database();
            return log;
        }
    }

    class Client
    {
        public static void Main(String[] args)
        {
            Factory factory;
            Log log;
            factory = new FileLogFactory();
            log = factory.CreateLog();
            log.Write();
            Console.ReadKey();
        }
    }
}
