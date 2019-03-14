using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    public interface IOperate               //前面加“I”为了解决命名冲突问题
    {
        void Estabish();
        void Delete();
    }

    class Bussiness1 : IOperate
    {
        void IOperate.Estabish()
        {
            Console.WriteLine("+1");
        }

        void IOperate.Delete()
        {
            Console.WriteLine("-1");
        }
    }

    class Bussiness2 : IOperate
    {
        void IOperate.Estabish()
        {
            Console.WriteLine("+2");
        }

        void IOperate.Delete()
        {
            Console.WriteLine("-2");
        }
    }

    interface IEstabishFactory              //前面加“I”为了解决命名冲突问题
    {
        IOperate EstabishFigure();
    }

    class Bussiness1Factory : IEstabishFactory
    {
        IOperate IEstabishFactory.EstabishFigure()
        {
            return new Bussiness1();
        }

    }


    class Bussiness2Factory : IEstabishFactory
    {
        IOperate IEstabishFactory.EstabishFigure()
        {
            return new Bussiness2();
        }

    }

    class AllClass
    {
        public static void Main(string[] args)
        {
            IEstabishFactory Factories;
            Factories = new Bussiness1Factory();
            IOperate Creates = Factories.EstabishFigure();
            Creates.Estabish();
        }
    }

}
